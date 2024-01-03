using HeadHunterAggregator.Domain.Entities;
using System.Linq.Expressions;

namespace HeadHunterAggregator.Domain.Infrastructure.Databases.Repositories
{
    public interface IRepository
    {
        TEntity Add<TEntity>(TEntity entity, CancellationToken cancellationToken = default)
            where TEntity : EntityBase;

        Task<TEntity?> FindOneByIdAsync<TEntity>(Guid id, CancellationToken cancellationToken = default)
            where TEntity : EntityBase;

        Task<TEntity?> FindOneByExpressionAsync<TEntity>(Expression<Func<TEntity, bool>> expression,
            CancellationToken cancellationToken = default) where TEntity : EntityBase;

        Task<TEntity> FindOneByExpressionOrAddAsync<TEntity>(TEntity entity, Expression<Func<TEntity, bool>> expression,
            CancellationToken cancellationToken = default) where TEntity : EntityBase;

        void Remove<TEntity>(TEntity entity, CancellationToken cancellationToken = default) where TEntity : EntityBase;
    }

    public interface IRepository<TEntity> where TEntity : EntityBase
    {
        TEntity Add(TEntity entity, CancellationToken cancellationToken = default);

        Task<TEntity?> FindOneByIdAsync(Guid id, CancellationToken cancellationToken = default);

        Task<TEntity?> FindOneByExpressionAsync(Expression<Func<TEntity, bool>> expression,
            CancellationToken cancellationToken = default);

        Task<TEntity> FindOneByExpressionOrAddAsync(TEntity entity, Expression<Func<TEntity, bool>> expression,
            CancellationToken cancellationToken = default);

        void Remove(TEntity entity, CancellationToken cancellationToken = default);
    }
}
