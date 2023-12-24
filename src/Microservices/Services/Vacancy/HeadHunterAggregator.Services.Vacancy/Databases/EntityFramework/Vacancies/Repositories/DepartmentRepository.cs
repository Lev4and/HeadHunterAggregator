using HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Entities;

namespace HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Repositories
{
    public class DepartmentRepository : VacanciesDbRepository<Department>, IDepartmentRepository
    {
        public DepartmentRepository(VacanciesDbContext dbContext) : base(dbContext)
        {
            
        }
    }
}