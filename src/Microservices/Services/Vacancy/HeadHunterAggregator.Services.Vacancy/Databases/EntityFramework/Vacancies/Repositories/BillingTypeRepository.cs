using HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Entities;

namespace HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Repositories
{
    public class BillingTypeRepository : VacanciesDbRepository<BillingType>
    {
        public BillingTypeRepository(VacanciesDbContext dbContext) : base(dbContext)
        {
            
        }
    }
}