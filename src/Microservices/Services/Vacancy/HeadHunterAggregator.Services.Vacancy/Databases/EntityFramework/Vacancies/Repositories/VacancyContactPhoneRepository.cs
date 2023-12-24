using HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Entities;

namespace HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Repositories
{
    public class VacancyContactPhoneRepository : VacanciesDbRepository<VacancyContactPhone>
    {
        public VacancyContactPhoneRepository(VacanciesDbContext dbContext) : base(dbContext)
        {
            
        }
    }
}