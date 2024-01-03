using HeadHunterAggregator.Domain.Entities;
using HeadHunterAggregator.Domain.Infrastructure.Databases;
using HeadHunterAggregator.Domain.Infrastructure.Databases.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace HeadHunterAggregator.Infrastructure.Databases.EntityFramework.Repositories
{
    public abstract class EntityFrameworkRepository<TDbContext> : IRepository
        where TDbContext : DbContext, IUnitOfWork
    {
        protected readonly TDbContext _dbContext;

        public EntityFrameworkRepository(TDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public TEntity Add<TEntity>(TEntity entity, CancellationToken cancellationToken = default)
            where TEntity : EntityBase
        {
            return _dbContext.Set<TEntity>().Add(entity).Entity;
        }

        public async Task<TEntity?> FindOneByIdAsync<TEntity>(Guid id, CancellationToken cancellationToken = default)
            where TEntity : EntityBase
        {
            return await _dbContext.Set<TEntity>().AsNoTracking()
                .SingleOrDefaultAsync(item => item.Id == id, cancellationToken);
        }

        public async Task<TEntity?> FindOneByExpressionAsync<TEntity>(Expression<Func<TEntity, bool>> expression,
            CancellationToken cancellationToken = default) where TEntity : EntityBase
        {
            return await _dbContext.Set<TEntity>().AsNoTracking()
                .SingleOrDefaultAsync(expression, cancellationToken);
        }

        public async Task<TEntity> FindOneByExpressionOrAddAsync<TEntity>(TEntity entity,
            Expression<Func<TEntity, bool>> expression, CancellationToken cancellationToken = default)
                where TEntity : EntityBase
        {
            return await FindOneByExpressionAsync(expression, cancellationToken)
                ?? Add(entity, cancellationToken);
        }

        public void Remove<TEntity>(TEntity entity, CancellationToken cancellationToken = default)
            where TEntity : EntityBase
        {
            _dbContext.Set<TEntity>().Remove(entity);
        }
    }

    public abstract class EntityFrameworkRepository<TDbContext, TEntity> : IRepository<TEntity>
        where TDbContext : DbContext, IUnitOfWork where TEntity : EntityBase
    {
        protected readonly TDbContext _dbContext;

        public EntityFrameworkRepository(TDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public TEntity Add(TEntity entity, CancellationToken cancellationToken = default)
        {
            return _dbContext.Set<TEntity>().Add(entity).Entity;
        }

        public async Task<TEntity?> FindOneByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _dbContext.Set<TEntity>().AsNoTracking()
                .SingleOrDefaultAsync(item => item.Id == id, cancellationToken);
        }

        public async Task<TEntity?> FindOneByExpressionAsync(Expression<Func<TEntity, bool>> expression, 
            CancellationToken cancellationToken = default)
        {
            return await _dbContext.Set<TEntity>().AsNoTracking()
                .SingleOrDefaultAsync(expression, cancellationToken);
        }

        public async Task<TEntity> FindOneByExpressionOrAddAsync(TEntity entity, 
            Expression<Func<TEntity, bool>> expression, CancellationToken cancellationToken = default)
        {
            return await FindOneByExpressionAsync(expression, cancellationToken) 
                ?? Add(entity, cancellationToken);
        }

        public void Remove(TEntity entity, CancellationToken cancellationToken = default)
        {
            _dbContext.Set<TEntity>().Remove(entity);
        }
    }
}
