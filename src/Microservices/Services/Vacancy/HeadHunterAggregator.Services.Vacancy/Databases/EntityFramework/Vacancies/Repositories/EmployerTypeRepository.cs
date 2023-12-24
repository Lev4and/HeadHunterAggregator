using HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Entities;

namespace HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Repositories
{
    public class EmployerTypeRepository : VacanciesDbRepository<EmployerType>, IEmployerTypeRepository
    {
        public EmployerTypeRepository(VacanciesDbContext dbContext) : base(dbContext)
        {
            
        }
    }
}