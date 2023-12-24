using HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Entities;

namespace HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Repositories
{
    public class EmploymentRepository : VacanciesDbRepository<Employment>, IEmploymentRepository
    {
        public EmploymentRepository(VacanciesDbContext dbContext) : base(dbContext)
        {
            
        }
    }
}