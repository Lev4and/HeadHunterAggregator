using HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Entities;

namespace HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Repositories
{
    public class VacancySalaryRepository : VacanciesDbRepository<VacancySalary>, IVacancySalaryRepository
    {
        public VacancySalaryRepository(VacanciesDbContext dbContext) : base(dbContext)
        {
            
        }
    }
}