using HeadHunter.HttpClients;
using HeadHunter.Models;
using Microsoft.Extensions.Logging;

namespace HeadHunter.Importer
{
    public class VacanciesImporter
    {
        private readonly ILogger<VacanciesImporter> _logger;
        private readonly HttpContext _context;

        private int _importedVacanciesPerHour;
        private DateTime _dateTo;
        private DateTime _dateFrom;
        private DateTime _startedAt;

        public VacanciesImporter(ILogger<VacanciesImporter> logger, HttpContext context)
        {
            _logger = logger;
            _context = context;
            _importedVacanciesPerHour = 0;
            _dateTo = DateTime.UtcNow;
            _dateFrom = DateTime.UtcNow.AddMinutes(-5);
            _startedAt = DateTime.UtcNow;
        }

        public async IAsyncEnumerable<Vacancy> GetVacanciesAsync()
        {
            while (true)
            {
                await foreach (var vacancy in GetVacanciesByPediodAsync())
                {
                    if (HourHasPassed()) ResetImportData();

                    if (IsLimitExceeded())
                    {
                        await Task.Delay(3600000);

                        continue;
                    }
                    else yield return vacancy;

                    _importedVacanciesPerHour += 1;
                }

                IncrementDateRangeFilters();

                await WaitAsync();
            }
        }

        private async IAsyncEnumerable<Vacancy> GetVacanciesByPediodAsync()
        {
            var found = await GetCountVacanciesAsync();

            _logger.LogInformation($"GetVacanciesByPediodAsync Found: {found}");
            _logger.LogInformation($"GetVacanciesByPediodAsync Pages: {found / 100 + 1}");

            for (var i = 1; i <= found / 100 + 1; i++)
            {
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
            var response = await _context.HeadHunter.Vacancies.GetVacanciesAsync(page, 100, _dateFrom, _dateTo);

            foreach (var vacancy in response?.Result?.Items ?? new Vacancy[0])
            {
                yield return vacancy;
            }
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
            else
            {
                _logger.LogWarning($"Failed of import vacancy - VacancyId: {vacancyId} CompanyId: {companyId}");
            }


            return vacancy;
        }

        private bool HourHasPassed()
        {
            return (DateTime.UtcNow - _startedAt).TotalMinutes > 60;
        }

        private void ResetImportData()
        {
            _startedAt = DateTime.UtcNow;
            _importedVacanciesPerHour = 0;
        }

        private bool IsLimitExceeded()
        {
            return _importedVacanciesPerHour > 3500;
        }

        private void IncrementDateRangeFilters()
        {
            _dateTo = _dateTo.AddMinutes(5);
            _dateFrom = _dateFrom.AddMinutes(5);
        }

        private async Task WaitAsync()
        {
            if (_dateTo > DateTime.UtcNow) await Task.Delay(_dateTo - DateTime.UtcNow);
        }
    }
}
