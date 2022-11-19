using HeadHunter.HttpClients;
using HeadHunter.Models;
using Microsoft.Extensions.Logging;

namespace HeadHunter.Importer
{
    public class VacanciesImporter
    {
        private const double _dateRangeMinuteIncrement = 5;
        private const int _limitImportedVacanciesPerHour = 3900;

        private readonly HttpContext _context;
        private readonly ILogger<VacanciesImporter> _logger;

        private long _maxVacancyId;
        private long _previousMaxVacancyId;

        private DateTime _dateTo;
        private DateTime _dateFrom;

        private List<DateTime> _timesImportVacancies;

        public VacanciesImporter(ILogger<VacanciesImporter> logger, HttpContext context)
        {
            _logger = logger;
            _context = context;

            _maxVacancyId = 0;
            _previousMaxVacancyId = 0;
            _timesImportVacancies = new List<DateTime>();
            _dateTo = DateTime.UtcNow.AddMinutes(-_dateRangeMinuteIncrement);
            _dateFrom = DateTime.UtcNow.AddMinutes(-_dateRangeMinuteIncrement * 2);
        }

        public async IAsyncEnumerable<long> GetVacancyIdsAsync()
        {
            _logger.LogInformation($"Date range filter value: from {_dateFrom} to {_dateTo}");

            await foreach (var vacancyId in GetVacancyIdsByPediodAsync())
            {
                OnVacancyImported();
                RemoveAllTimesImportVacanciesLaterHour();

                if (IsLimitExceeded()) await PauseAsync();
                yield return vacancyId;
            }

            IncrementDateRangeFilters();

            await WaitAsync();
        }

        private async IAsyncEnumerable<long> GetVacancyIdsByPediodAsync()
        {
            var oldPreviousMaxVacancyId = _previousMaxVacancyId;

            _previousMaxVacancyId = _maxVacancyId;
            _maxVacancyId = await GetMaxVacancyIdAsync();

            if (_previousMaxVacancyId != 0 && _previousMaxVacancyId != oldPreviousMaxVacancyId)
            {
                for (var i = _previousMaxVacancyId + 1; i <= _maxVacancyId; i++)
                {
                    yield return i;
                }
            }
        }

        private async Task<long> GetMaxVacancyIdAsync()
        {
            var items = await GetVacanciesAsync();

            return items.Count() > 0 ? items.Max(item => Convert.ToInt64(item.Id)) : 0;
        }

        private async Task<IEnumerable<Vacancy>> GetVacanciesAsync()
        {
            var response = await _context.HeadHunter.Vacancies.GetVacanciesAsync(1, 100, _dateFrom, _dateTo);

            return response.Result.Items;
        }

        public async Task<bool> ImportVacancyAsync(long vacancyId)
        {
            if (!await ContainsVacancyByIdAsync(vacancyId))
            {
                var vacancy = await GetVacancyByIdAsync(vacancyId);

                if (IsValidVacancy(vacancy))
                {
                    vacancy.Employer = await GetEmployerByIdAsync(Convert.ToInt64(vacancy.Employer.Id));

                    await SaveVacancyAsync(vacancy);
                }
                else _logger.LogWarning($"Vacancy not exists in hh.ru or system blocked the request - VacancyId: {vacancyId}");

                return true;
            }

            return false;
        }

        private async Task<bool> ContainsVacancyByIdAsync(long vacancyId)
        {
            var vacancyResponse = await _context.Resource.Vacancies.GetVacancyInfoByHeadHunterIdAsync(vacancyId);

            return vacancyResponse.Result != null;
        }

        private void RemoveAllTimesImportVacanciesLaterHour()
        {
            _timesImportVacancies.RemoveAll(TimesImportVacanciesLaterHour());
        }

        private async Task<Vacancy> GetVacancyByIdAsync(long vacancyId)
        {
            var vacancyResponse = await _context.HeadHunter.Vacancies.GetVacancyAsync(vacancyId);

            return vacancyResponse.Result;
        }

        private async Task<Employer> GetEmployerByIdAsync(long employerId)
        {
            var employerResponse = await _context.HeadHunter.Employers.GetEmployerAsync(employerId);

            return employerResponse.Result;
        }

        private bool IsLimitExceeded()
        {
            return _timesImportVacancies.Count > _limitImportedVacanciesPerHour;
        }

        private void IncrementDateRangeFilters()
        {
            _dateTo = _dateTo.AddMinutes(_dateRangeMinuteIncrement);
            _dateFrom = _dateFrom.AddMinutes(_dateRangeMinuteIncrement);
        }

        private Predicate<DateTime> TimesImportVacanciesLaterHour()
        {
            return (time) => (DateTime.UtcNow - time).TotalMinutes > 60;
        }

        private async Task PauseAsync()
        {
            var difference = DateTime.UtcNow - _timesImportVacancies.Min();

            var delay = new TimeSpan(1, 0, 0).Subtract(difference);

            _logger.LogWarning($"The limit has been exceeded. Import will be paused on " +
                $"{string.Format("{0:%h} hours {0:%m} minutes {0:%s} seconds {0:%f} milliseconds", delay)}.");

            await Task.Delay((int)delay.TotalMilliseconds);
        }

        private async Task WaitAsync()
        {
            if (_dateTo > DateTime.UtcNow.AddMinutes(-_dateRangeMinuteIncrement)) await Task.Delay(_dateTo - DateTime.UtcNow.AddMinutes(-_dateRangeMinuteIncrement));
        }

        private void OnVacancyImported()
        {
            _timesImportVacancies.Add(DateTime.UtcNow);

            _logger.LogInformation($"Imported vacancies per hour: {_timesImportVacancies.Count}");
        }

        private bool IsValidVacancy(Vacancy vacancy)
        {
            return !string.IsNullOrEmpty(vacancy.Id) && !string.IsNullOrEmpty(vacancy.Name);
        }

        private async Task SaveVacancyAsync(Vacancy vacancy)
        {
            await _context.Resource.ImportVacancies.ImportAsync(vacancy);
        }
    }
}
