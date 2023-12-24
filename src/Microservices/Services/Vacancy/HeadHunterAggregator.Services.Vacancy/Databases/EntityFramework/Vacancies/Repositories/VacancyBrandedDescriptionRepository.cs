using HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Entities;

namespace HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Repositories
{
    public class VacancyBrandedDescriptionRepository : VacanciesDbRepository<VacancyBrandedDescription>, 
        IVacancyBrandedDescriptionRepository
    {
        public VacancyBrandedDescriptionRepository(VacanciesDbContext dbContext) : base(dbContext)
        {
            
        }
    }
}