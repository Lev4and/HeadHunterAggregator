using HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Entities;

namespace HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Repositories
{
    public class ExperienceRepository : VacanciesDbRepository<Experience>
    {
        public ExperienceRepository(VacanciesDbContext dbContext) : base(dbContext)
        {
            
        }
    }
}