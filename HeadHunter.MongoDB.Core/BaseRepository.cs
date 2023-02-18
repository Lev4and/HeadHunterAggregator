using HeadHunter.Core.Domain;
using HeadHunter.Core.Specification;
using HeadHunter.MongoDB.Core.Domain;
using MongoDB.Driver;

namespace HeadHunter.MongoDB.Core
{
    public class BaseRepository : IMongoDBRepository
    {
        private readonly IMongoDatabase _database;

        public BaseRepository(IMongoDatabase database)
        {
            _database = database;
        }

        public Task<TEntity> AddAsync<TEntity>(TEntity entity) where TEntity : EntityBase, 
            IAggregateRoot, IEqualSpecification<TEntity>
        {
            throw new NotImplementedException();
        }

        public ValueTask<long> CountAsync<TEntity>(IGridSpecification<TEntity> spec) where TEntity : EntityBase, 
            IAggregateRoot
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TEntity>> FindAsync<TEntity>(ISpecification<TEntity> specification) where TEntity : 
            EntityBase, IAggregateRoot, IEqualSpecification<TEntity>
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TEntity>> FindAsync<TEntity>(IGridSpecification<TEntity> spec) where TEntity :
            EntityBase, IAggregateRoot
        {
            throw new NotImplementedException();
        }

        public Task<TEntity?> FindByExpressionAsync<TEntity>(IEqualSpecification<TEntity> specification) where TEntity : 
            EntityBase, IAggregateRoot, IEqualSpecification<TEntity>
        {
            throw new NotImplementedException();
        }

        public Task<TEntity?> FindByIdAsync<TEntity>(Guid id) where TEntity : EntityBase, IAggregateRoot, 
            IEqualSpecification<TEntity>
        {
            throw new NotImplementedException();
        }

        public Task<TEntity?> FindOneAsync<TEntity>(ISpecification<TEntity> specification) where TEntity : 
            EntityBase, IAggregateRoot, IEqualSpecification<TEntity>
        {
            throw new NotImplementedException();
        }

        public Task RemoveAsync<TEntity>(TEntity entity) where TEntity : EntityBase, IAggregateRoot, 
            IEqualSpecification<TEntity>
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> TryImportAsync<TEntity>(TEntity entity) where TEntity : EntityBase, IAggregateRoot, 
            IEqualSpecification<TEntity>
        {
            throw new NotImplementedException();
        }
    }
}
