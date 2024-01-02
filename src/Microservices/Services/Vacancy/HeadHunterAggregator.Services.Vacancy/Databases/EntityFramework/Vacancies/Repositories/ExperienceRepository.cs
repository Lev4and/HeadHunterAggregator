using HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Entities;

namespace HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Repositories
{
    public class ExperienceRepository : VacanciesDbRepository<Experience>, IExperienceRepository
    {
        public ExperienceRepository(VacanciesDbContext dbContext) : base(dbContext)
        {
            
        }

        public Task<Experience> FindOneByHeadHunterIdOrAddAsync(Experience entity, string headHunterId, 
            CancellationToken cancellationToken = default)
        {
            return FindOneByExpressionOrAddAsync(entity, experience => experience.HeadHunterId == headHunterId,
                cancellationToken);
        }
    }
}