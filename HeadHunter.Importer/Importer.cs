using HeadHunter.HttpClients;
using HeadHunter.Models;

namespace HeadHunter.Importer
{
    public class Importer
    {
        private readonly HttpContext _context;

        private DateTime _dateTo;
        private DateTime _dateFrom;

        public Importer(HttpContext context)
        {
            _context = context;

            _dateTo = DateTime.UtcNow;
            _dateFrom = DateTime.UtcNow.AddMinutes(-5);
        }

        public async Task<Vacancy> GetVacancyAsync(long vacancyId, long companyId)
        {
            var vacancyResponse = await _context.HeadHunter.Vacancies.GetVacancyAsync(vacancyId);
            var companyResponse = await _context.HeadHunter.Employers.GetEmployerAsync(companyId);

            var vacancy = vacancyResponse.Result as Vacancy;
            var company = companyResponse.Result as Employer;

            vacancy.Employer = company;

            return vacancy;
        }

        public async IAsyncEnumerable<Vacancy> GetVacanciesAsync()
        {
            while(_dateFrom < DateTime.UtcNow)
            {
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

            for (var i = 1; i <= found / 100 + 1; i++)
            {
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
