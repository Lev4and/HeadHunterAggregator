using HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Entities;

namespace HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Repositories
{
    public class IndustryRepository : VacanciesDbRepository<Industry>
    {
        public IndustryRepository(VacanciesDbContext dbContext) : base(dbContext)
        {
            
        }
    }
}