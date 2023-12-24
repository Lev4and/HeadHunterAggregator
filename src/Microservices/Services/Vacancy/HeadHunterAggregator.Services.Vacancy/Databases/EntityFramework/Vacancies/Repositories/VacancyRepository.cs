using HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Entities;

namespace HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Repositories
{
    public class VacancyRepository : VacanciesDbRepository<Entities.Vacancy>
    {
        public VacancyRepository(VacanciesDbContext dbContext) : base(dbContext)
        {
            
        }
    }
}