using HeadHunterAggregator.Domain.Entities;
using HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Entities;

namespace HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Repositories
{
    public interface IFromHeadHunterRepository<TEntity> where TEntity : EntityBase, IFromHeadHunter
    {
        Task<TEntity> FindOneByHeadHunterIdOrAddAsync(TEntity entity, string headHunterId,
            CancellationToken cancellationToken = default);
    }
}
