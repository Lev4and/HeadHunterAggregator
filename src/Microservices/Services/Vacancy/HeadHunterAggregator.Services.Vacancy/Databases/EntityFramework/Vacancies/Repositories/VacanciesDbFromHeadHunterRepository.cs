using HeadHunterAggregator.Domain.Entities;
using HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Entities;

namespace HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Repositories
{
    public class VacanciesDbFromHeadHunterRepository : VacanciesDbRepository, IFromHeadHunterRepository
    {
        public VacanciesDbFromHeadHunterRepository(VacanciesDbContext dbContext) : base(dbContext)
        {

        }

        public async Task<TEntity> FindOneByHeadHunterIdOrAddAsync<TEntity>(TEntity entity, string headHunterId, 
            CancellationToken cancellationToken = default) where TEntity : EntityBase, IFromHeadHunter
        {
            return await FindOneByExpressionOrAddAsync(entity, item => item.HeadHunterId == headHunterId,
                cancellationToken);
        }
    }
}
