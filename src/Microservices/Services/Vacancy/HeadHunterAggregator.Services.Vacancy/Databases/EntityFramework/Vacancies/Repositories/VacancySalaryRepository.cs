using HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Entities;

namespace HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Repositories
{
    public class VacancySalaryRepository : VacanciesDbRepository<VacancySalary>
    {
        public VacancySalaryRepository(VacanciesDbContext dbContext) : base(dbContext)
        {
            
        }
    }
}