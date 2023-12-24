using HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Entities;

namespace HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Repositories
{
    public class EmployerDescriptionRepository : VacanciesDbRepository<EmployerDescription>
    {
        public EmployerDescriptionRepository(VacanciesDbContext dbContext) : base(dbContext)
        {
            
        }
    }
}