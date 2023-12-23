using HeadHunterAggregator.Domain.Entities;
using HeadHunterAggregator.Domain.Infrastructure.Databases;
using HeadHunterAggregator.Domain.Infrastructure.Databases.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace HeadHunterAggregator.Infrastructure.Databases.EntityFramework.Repositories
{
    public abstract class EntityFrameworkRepository<TDbContext, TEntity> : IRepository<TEntity>
        where TDbContext : DbContext, IUnitOfWork where TEntity : EntityBase
    {
        protected readonly TDbContext _dbContext;

        public EntityFrameworkRepository(TDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<TEntity> CreateAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            return await Task.FromResult(_dbContext.Set<TEntity>().Add(entity).Entity);
        }

        public async Task<TEntity?> FindByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _dbContext.Set<TEntity>().AsNoTracking()
                .SingleOrDefaultAsync(item => item.Id == id, cancellationToken);
        }

        public async Task<TEntity?> FindByExpressionAsync(Expression<Func<TEntity, bool>> expression, 
            CancellationToken cancellationToken = default)
        {
            return await _dbContext.Set<TEntity>().AsNoTracking()
                .SingleOrDefaultAsync(expression, cancellationToken);
        }

        public async Task<TEntity> FindByExpressionOrCreateAsync(TEntity entity, 
            Expression<Func<TEntity, bool>> expression, CancellationToken cancellationToken = default)
        {
            return await FindByExpressionAsync(expression, cancellationToken) ?? await CreateAsync(entity, cancellationToken);
        }

        public async Task RemoveAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            await Task.FromResult(_dbContext.Set<TEntity>().Remove(entity));
        }
    }
}
