using HeadHunter.HttpClients;
using HeadHunter.HttpClients.HeadHunter;
using HeadHunter.Models;
using Microsoft.Extensions.Logging;

namespace HeadHunter.Importer
{
    public class VacanciesImporter
    {
        private const int _vacanciesPerPage = 100;
        private const int _errorNewVacancyId = 5000;
        private const double _dateRangeMinuteIncrement = 5;
        private const int _limitImportedVacanciesPerHour = 3900;

        private readonly HttpContext _context;
        private readonly ILogger<VacanciesImporter> _logger;

        private long _newVacancyId;

        private DateTime _dateTo;
        private DateTime _dateFrom;

        private List<DateTime> _timesImportVacancies;

        public VacanciesImporter(ILogger<VacanciesImporter> logger, HttpContext context)
        {
            _logger = logger;
            _context = context;

            _newVacancyId = 0;
            _timesImportVacancies = new List<DateTime>();
            _dateTo = DateTime.UtcNow.AddMinutes(-_dateRangeMinuteIncrement);
            _dateFrom = DateTime.UtcNow.AddMinutes(-_dateRangeMinuteIncrement * 2);
        }

        public async IAsyncEnumerable<Vacancy> GetVacanciesAsync()
        {
            _logger.LogInformation($"Date range filter value: From - {_dateFrom} To - {_dateTo}");

            await foreach (var vacancy in GetVacanciesByPediodAsync())
            {
                RemoveAllTimesImportVacanciesLaterHour();

                if (IsLimitExceeded()) await OneHourIdleAsync();
                else if (IsNewVacancy(vacancy)) yield return vacancy;
            }

            IncrementDateRangeFilters();

            await WaitAsync();
        }

        private async IAsyncEnumerable<Vacancy> GetVacanciesByPediodAsync()
        {
            var found = await GetCountVacanciesAsync();

            await RecalculateNewVacancyIdAsync();

            _logger.LogInformation($"VacanciesByPediod Found: {found}");
            _logger.LogInformation($"VacanciesByPediod Pages: {found / _vacanciesPerPage + 1}");

            for (var i = 1; i <= found / _vacanciesPerPage + 1; i++)
            {
                _logger.LogInformation($"VacanciesByPediod Page: {i}");

                await foreach (var vacancy in GetVacanciesByPageAsync(i))
                {
                    yield return vacancy;
                }
            }
        }

        private async Task<int> GetCountVacanciesAsync()
        {
            var response = await _context.HeadHunter.Vacancies.GetVacanciesAsync(1, 1, _dateFrom, _dateTo);

            return response?.Result?.Found ?? 0;
        }

        private async Task RecalculateNewVacancyIdAsync()
        {
            var response = await _context.HeadHunter.Vacancies.GetVacanciesAsync(1, 1, _dateFrom, _dateTo);
            var items = response.Result.Items;

            var newVacancyId = items.Length > 0 ? items.Max(item => Convert.ToInt64(item.Id)) : 0;

            if (newVacancyId > _newVacancyId) _newVacancyId = newVacancyId;
        }

        private async IAsyncEnumerable<Vacancy> GetVacanciesByPageAsync(int page)
        {
            if (page * _vacanciesPerPage < HeadHunterConstants.OffsetUpperValue)
            {
                var response = await _context.HeadHunter.Vacancies.GetVacanciesAsync(page, _vacanciesPerPage, _dateFrom, _dateTo);

                foreach (var vacancy in response?.Result?.Items ?? new Vacancy[0])
                {
                    yield return vacancy;
                }
            }
            else _logger.LogWarning($"The page {page} will be skipped");
        }

        public async Task<bool> ImportVacancyAsync(Vacancy vacancy)
        {
            var vacancyId = Convert.ToInt64(vacancy.Id);
            var companyId = Convert.ToInt64(vacancy.Employer.Id);

            var vacancyFromDbResponse = await _context.Resource.Vacancies.GetVacancyIdAsync(vacancyId);
            var companyFromDbResponse = await _context.Resource.Employers.GetEmployerByIdAsync(companyId);

            var vacancyFromDb = vacancyFromDbResponse.Result;
            var companyFromDb = companyFromDbResponse.Result;

            if (vacancyFromDb == null)
            {
                var vacancyFromHeadHunterResponse = await _context.HeadHunter.Vacancies.GetVacancyAsync(vacancyId);
                var vacancyFromHeadHunter = vacancyFromHeadHunterResponse.Result;

                if (companyFromDb == null)
                {
                    var companyFromHeadHunterResponse = await _context.HeadHunter.Employers.GetEmployerAsync(companyId);
                    var companyFromHeadHunter = companyFromHeadHunterResponse.Result;

                    vacancyFromHeadHunter.Employer = companyFromHeadHunter;
                }

                if (IsValidVacancy(vacancyFromHeadHunter)) await SaveVacancyAsync(vacancyFromHeadHunter);
                else _logger.LogWarning($"Failed of save vacancy - VacancyId: {vacancyId} CompanyId: {companyId}");

                return true;
            }

            return false;
        }

        private void RemoveAllTimesImportVacanciesLaterHour()
        {
            _timesImportVacancies.RemoveAll(TimesImportVacanciesLaterHour());
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

        private async Task OneHourIdleAsync()
        {
            _logger.LogWarning("The limit has been exceeded. Import will be suspended on one hour.");

            await Task.Delay(1000 * 60 * 60);
        }

        private bool IsNewVacancy(Vacancy vacancy)
        {
            return Convert.ToInt64(vacancy.Id) > _newVacancyId - _errorNewVacancyId;
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

            OnVacancyImported();
        }
    }
}
