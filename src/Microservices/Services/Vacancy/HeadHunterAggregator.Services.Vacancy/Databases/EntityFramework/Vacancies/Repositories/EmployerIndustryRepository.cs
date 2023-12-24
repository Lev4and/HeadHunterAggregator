using HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Entities;

namespace HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Repositories
{
    public class EmployerIndustryRepository : VacanciesDbRepository<EmployerIndustry>
    {
        public EmployerIndustryRepository(VacanciesDbContext dbContext) : base(dbContext)
        {
            
        }
    }
}