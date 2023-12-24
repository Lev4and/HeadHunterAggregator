using HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Entities;

namespace HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Repositories
{
    public class AreaRepository : VacanciesDbRepository<Area>
    {
        public AreaRepository(VacanciesDbContext dbContext) : base(dbContext)
        {
            
        }
    }
}