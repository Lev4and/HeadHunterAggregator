using HeadHunter.Core.Domain;
using HeadHunter.Core.Specification;
using Microsoft.EntityFrameworkCore;

namespace HeadHunter.EntityFramework.Core
{
    public class BaseRepository : IEntityFrameworkRepository
    {
        private readonly DbContext _context;

        public BaseRepository(DbContext context)
        {
            _context = context;
        }

        public async Task<TEntity?> FindByIdAsync<TEntity>(Guid id) where TEntity : EntityBase, IAggregateRoot,
            IEqualSpecification<TEntity>
        {
            return await _context.Set<TEntity>().AsNoTracking().SingleOrDefaultAsync(item => item.Id == id);
        }

        public async Task<TEntity?> FindByExpressionAsync<TEntity>(IEqualSpecification<TEntity> specification) 
            where TEntity : EntityBase, IAggregateRoot, IEqualSpecification<TEntity>
        {
            return await _context.Set<TEntity>().AsNoTracking().SingleOrDefaultAsync(specification.IsEqual);
        }

        public async Task<TEntity?> FindOneAsync<TEntity>(ISpecification<TEntity> specification) where TEntity :
            EntityBase, IAggregateRoot, IEqualSpecification<TEntity>
        {
            return await GetQuery(_context.Set<TEntity>(), specification).AsNoTracking().FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<TEntity>> FindAsync<TEntity>(ISpecification<TEntity> specification) where TEntity : 
            EntityBase, IAggregateRoot, IEqualSpecification<TEntity>
        {
            return await GetQuery(_context.Set<TEntity>(), specification).AsNoTracking().ToListAsync();
        }

        public async ValueTask<long> CountAsync<TEntity>(IGridSpecification<TEntity> specification) where TEntity : 
            EntityBase, IAggregateRoot
        {
            specification.IsPagingEnabled = false;

            return await ValueTask.FromResult(GetQuery(_context.Set<TEntity>(), specification).LongCount());
        }

        public async Task<IEnumerable<TEntity>> FindAsync<TEntity>(IGridSpecification<TEntity> specification) where TEntity : 
            EntityBase, IAggregateRoot
        {
            return await GetQuery(_context.Set<TEntity>(), specification).AsNoTracking().ToListAsync();
        }

        public async Task<TEntity> AddAsync<TEntity>(TEntity entity) where TEntity : EntityBase, IAggregateRoot,
            IEqualSpecification<TEntity>
        {
            await _context.Set<TEntity>().SingleInsertAsync(entity);

            return entity;
        }

        public async Task<TEntity> ImportAsync<TEntity>(TEntity entity) where TEntity : EntityBase, IAggregateRoot,
            IEqualSpecification<TEntity>
        {
            return (await FindByExpressionAsync(entity)) ?? await AddAsync(entity);
        }

        public async Task RemoveAsync<TEntity>(TEntity entity) where TEntity : EntityBase, IAggregateRoot,
            IEqualSpecification<TEntity>
        {
            await _context.Set<TEntity>().SingleDeleteAsync(entity);
        }

        private static IQueryable<TEntity> GetQuery<TEntity>(IQueryable<TEntity> inputQuery,
            ISpecification<TEntity> specification) where TEntity : EntityBase, IAggregateRoot
        {
            var query = inputQuery;

            if (specification.Criteria != null)
            {
                query = query.Where(specification.Criteria);
            }

            query = specification.Includes
                .Aggregate(query, (current, include) => current.Include(include));

            query = specification.IncludeStrings
                .Aggregate(query, (current, include) => current.Include(include));

            if (specification.OrderBy != null) 
                query = query.OrderBy(specification.OrderBy);
            else if (specification.OrderByDescending != null) 
                query = query.OrderByDescending(specification.OrderByDescending);

            if (specification.GroupBy != null) 
                query = query.GroupBy(specification.GroupBy)
                    .SelectMany(item => item);

            if (specification.IsPagingEnabled) 
                query = query.Skip(specification.Skip - 1)
                    .Take(specification.Take);

            return query;
        }

        private static IQueryable<TEntity> GetQuery<TEntity>(IQueryable<TEntity> inputQuery,
            IGridSpecification<TEntity> specification) where TEntity : EntityBase, IAggregateRoot
        {
            var query = inputQuery;

            query = specification.Includes
                .Aggregate(query, (current, include) => current.Include(include));

            query = specification.IncludeStrings
                .Aggregate(query, (current, include) => current.Include(include));

            if (specification.OrderBy != null) 
                query = query.OrderBy(specification.OrderBy);
            else if (specification.OrderByDescending != null) 
                query = query.OrderByDescending(specification.OrderByDescending);

            if (specification.GroupBy != null) 
                query = query.GroupBy(specification.GroupBy)
                    .SelectMany(item => item);

            if (specification.IsPagingEnabled) 
                query = query.Skip(specification.Skip - 1)
                    .Take(specification.Take);

            return query;
        }
    }
}
