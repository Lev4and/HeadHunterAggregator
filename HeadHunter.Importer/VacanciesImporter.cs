using HeadHunter.HttpClients;
using HeadHunter.HttpClients.HeadHunter;
using HeadHunter.Models;
using Microsoft.Extensions.Logging;

namespace HeadHunter.Importer
{
    public class VacanciesImporter
    {
        private readonly HttpContext _context;
        private readonly int _vacanciesPerPage;
        private readonly double _dateRangeIncrement;
        private readonly int _limitImportedVacanciesPerHour;
        private readonly ILogger<VacanciesImporter> _logger;

        private DateTime _dateTo;
        private DateTime _dateFrom;

        private List<DateTime> _timesImportVacancies;

        public VacanciesImporter(ILogger<VacanciesImporter> logger, HttpContext context)
        {
            _logger = logger;
            _context = context;

            _vacanciesPerPage = 100;
            _dateRangeIncrement = 2.5;
            _dateTo = DateTime.UtcNow;
            _limitImportedVacanciesPerHour = 3900;
            _timesImportVacancies = new List<DateTime>();
            _dateFrom = DateTime.UtcNow.AddMinutes(-_dateRangeIncrement);
        }

        public async IAsyncEnumerable<Vacancy> GetVacanciesAsync()
        {
            while (true)
            {
                _logger.LogInformation($"Date range filter value: From - {_dateFrom} To - {_dateTo}");

                await foreach (var vacancy in GetVacanciesByPediodAsync())
                {
                    RemoveAllTimesImportVacanciesLaterHour();

                    if (IsLimitExceeded())
                    {
                        _logger.LogWarning("The limit has been exceeded. Import will be suspended on one hour.");

                        await Task.Delay(3600000);

                        continue;
                    }
                    else yield return vacancy;

                    _timesImportVacancies.Add(DateTime.UtcNow);

                    _logger.LogInformation($"Imported vacancies per hour: {_timesImportVacancies.Count}");
                }

                IncrementDateRangeFilters();

                await WaitAsync();
            }
        }

        private async IAsyncEnumerable<Vacancy> GetVacanciesByPediodAsync()
        {
            var found = await GetCountVacanciesAsync();

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

        public async Task<Vacancy> ImportVacancyAsync(long vacancyId, long companyId)
        {
            var vacancyResponse = await _context.HeadHunter.Vacancies.GetVacancyAsync(vacancyId);
            var companyResponse = await _context.HeadHunter.Employers.GetEmployerAsync(companyId);

            var vacancy = vacancyResponse.Result;
            var company = companyResponse.Result;

            vacancy.Employer = company;

            if (!string.IsNullOrEmpty(vacancy.Id) && !string.IsNullOrEmpty(vacancy.Name))
            {
                await _context.Resource.ImportVacancies.ImportAsync(vacancy);
            }
            else _logger.LogWarning($"Failed of import vacancy - VacancyId: {vacancyId} CompanyId: {companyId}");


            return vacancy;
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
            _dateTo = _dateTo.AddMinutes(_dateRangeIncrement);
            _dateFrom = _dateFrom.AddMinutes(_dateRangeIncrement);
        }

        private Predicate<DateTime> TimesImportVacanciesLaterHour()
        {
            return (time) => (DateTime.UtcNow - time).TotalMinutes > 60;
        }

        private async Task WaitAsync()
        {
            if (_dateTo > DateTime.UtcNow) await Task.Delay(_dateTo - DateTime.UtcNow);
        }
    }
}
