using HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Entities;

namespace HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Repositories
{
    public class EmployerBrandedDescriptionRepository : VacanciesDbRepository<EmployerBrandedDescription>, 
        IEmployerBrandedDescriptionRepository
    {
        public EmployerBrandedDescriptionRepository(VacanciesDbContext dbContext) : base(dbContext)
        {
            
        }
    }
}