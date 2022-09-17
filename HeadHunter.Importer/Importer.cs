using HeadHunter.HttpClients;
using HeadHunter.Models;
using Microsoft.Extensions.Logging;

namespace HeadHunter.Importer
{
    public class Importer
    {
        private readonly ILogger<Importer> _logger;
        private readonly HttpContext _context;

        private DateTime _dateTo;
        private DateTime _dateFrom;

        public Importer(ILogger<Importer> logger, HttpContext context)
        {
            _logger = logger;
            _context = context;

            _dateTo = DateTime.UtcNow;
            _dateFrom = DateTime.UtcNow.AddMinutes(-5);
        }

        public async Task<Vacancy> GetVacancyAsync(long vacancyId, long companyId)
        {
            _logger.LogInformation($"GetVacancyAsync VacancyId: {vacancyId} CompanyId: {companyId}");

            var vacancyResponse = await _context.HeadHunter.Vacancies.GetVacancyAsync(vacancyId);
            var companyResponse = await _context.HeadHunter.Employers.GetEmployerAsync(companyId);

            var vacancy = vacancyResponse.Result as Vacancy;
            var company = companyResponse.Result as Employer;

            vacancy.Employer = company;

            await _context.Resource.ImportVacancies.Import(vacancy);

            return vacancy;
        }

        public async IAsyncEnumerable<Vacancy> GetVacanciesAsync()
        {
            while(_dateFrom < DateTime.UtcNow)
            {
                _logger.LogInformation($"GetVacanciesAsync DateFrom: {_dateFrom.ToString("dd.MM.yyyy HH:mm:ss")}");

                await foreach (var vacancy in GetVacanciesByPediodAsync())
                {
                    yield return vacancy;
                }

                _dateTo = _dateTo.AddMinutes(5);
                _dateFrom = _dateFrom.AddMinutes(5);

                if (_dateTo > DateTime.UtcNow) await Task.Delay(_dateTo - DateTime.UtcNow);
            }
        }

        private async IAsyncEnumerable<Vacancy> GetVacanciesByPediodAsync()
        {
            var found = await GetCountVacanciesAsync();

            _logger.LogInformation($"GetVacanciesByPediodAsync Found: {found}");
            _logger.LogInformation($"GetVacanciesByPediodAsync Pages: {found / 100 + 1}");

            for (var i = 1; i <= found / 100 + 1; i++)
            {
                _logger.LogInformation($"GetVacanciesByPediodAsync Page: {i}");

                await foreach (var vacancy in GetVacanciesByPageAsync(i))
                {
                    yield return vacancy;
                }
            }
        }

        private async IAsyncEnumerable<Vacancy> GetVacanciesByPageAsync(int page)
        {
            var response = await _context.HeadHunter.Vacancies.GetVacanciesAsync(page, 100, _dateFrom, _dateTo);

            foreach (var vacancy in response?.Result?.Items ?? new Vacancy[0])
            {
                _logger.LogInformation($"GetVacanciesByPageAsync Vacancy: Id - {vacancy.Id} Name - " +
                    $"{vacancy.Name} CreatedAt - {vacancy.CreatedAt.ToString("dd.MM.yyyy HH:mm:ss")} " +
                    $"Company - {vacancy.Employer.Name} Area - {vacancy.Area.Name} Salary from - {vacancy.Salary?.From}");

                yield return vacancy;
            }
        }

        private async Task<int> GetCountVacanciesAsync()
        {
            var response = await _context.HeadHunter.Vacancies.GetVacanciesAsync(1, 1, _dateFrom, _dateTo);

            return response?.Result?.Found ?? 0;
        }
    }
}
