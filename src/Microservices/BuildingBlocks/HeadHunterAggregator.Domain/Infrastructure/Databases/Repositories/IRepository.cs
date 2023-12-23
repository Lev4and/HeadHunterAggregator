using HeadHunterAggregator.Domain.Entities;
using System.Linq.Expressions;

namespace HeadHunterAggregator.Domain.Infrastructure.Databases.Repositories
{
    public interface IRepository<TEntity> where TEntity : EntityBase
    {
        Task<TEntity> CreateAsync(TEntity entity, CancellationToken cancellationToken = default);

        Task<TEntity?> FindByIdAsync(Guid id, CancellationToken cancellationToken = default);

        Task<TEntity?> FindByExpressionAsync(Expression<Func<TEntity, bool>> expression,
            CancellationToken cancellationToken = default);

        Task<TEntity> FindByExpressionOrCreateAsync(TEntity entity, Expression<Func<TEntity, bool>> expression,
            CancellationToken cancellationToken = default);

        Task RemoveAsync(TEntity entity, CancellationToken cancellationToken = default);
    }
}
