using HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Entities;

namespace HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Repositories
{
    public class VacancyBrandedDescriptionRepository : VacanciesDbRepository<VacancyBrandedDescription>
    {
        public VacancyBrandedDescriptionRepository(VacanciesDbContext dbContext) : base(dbContext)
        {
            
        }
    }
}