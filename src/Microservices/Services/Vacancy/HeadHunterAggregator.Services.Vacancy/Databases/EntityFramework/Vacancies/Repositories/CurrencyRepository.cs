using HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Entities;

namespace HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Repositories
{
    public class CurrencyRepository : VacanciesDbRepository<Currency>
    {
        public CurrencyRepository(VacanciesDbContext dbContext) : base(dbContext)
        {
            
        }
    }
}