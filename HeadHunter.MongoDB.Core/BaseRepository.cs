using HeadHunter.Core.Domain;
using HeadHunter.Core.Specification;
using MongoDB.Driver;

namespace HeadHunter.MongoDB.Core
{
    public abstract class BaseRepository : IMongoDbRepository
    {
        private readonly IMongoDatabase _database;

        public abstract Dictionary<Type, string> Collections { get; }

        public BaseRepository(IMongoDatabase database)
        {
            _database = database;
        }

        public async Task<TEntity> AddAsync<TEntity>(TEntity entity) where TEntity : EntityBase, 
            IAggregateRoot, IEqualSpecification<TEntity>
        {
            await _database.GetCollection<TEntity>(Collections[typeof(TEntity)]).InsertOneAsync(entity);

            return entity;
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

        public async Task<TEntity?> FindByExpressionAsync<TEntity>(IEqualSpecification<TEntity> specification) where TEntity : 
            EntityBase, IAggregateRoot, IEqualSpecification<TEntity>
        {
            return await _database.GetCollection<TEntity>(Collections[typeof(TEntity)])
                .Find(specification.IsEqual).FirstOrDefaultAsync();
        }

        public async Task<TEntity?> FindByIdAsync<TEntity>(Guid id) where TEntity : EntityBase, IAggregateRoot, 
            IEqualSpecification<TEntity>
        {
            return await _database.GetCollection<TEntity>(Collections[typeof(TEntity)])
                .Find(item => item.Id == id).FirstOrDefaultAsync();
        }

        public Task<TEntity?> FindOneAsync<TEntity>(ISpecification<TEntity> specification) where TEntity : 
            EntityBase, IAggregateRoot, IEqualSpecification<TEntity>
        {
            throw new NotImplementedException();
        }

        public async Task RemoveAsync<TEntity>(TEntity entity) where TEntity : EntityBase, IAggregateRoot, 
            IEqualSpecification<TEntity>
        {
            await _database.GetCollection<TEntity>(Collections[typeof(TEntity)]).DeleteOneAsync(item => 
                item.Id == entity.Id);
        }

        public async Task<TEntity> ImportAsync<TEntity>(TEntity entity) where TEntity : EntityBase, IAggregateRoot, 
            IEqualSpecification<TEntity>
        {
            return (await FindByExpressionAsync(entity)) ?? await AddAsync(entity);
        }
        public async Task<bool> ContainsIndexKeyAsync<TEntity>(string name) where TEntity : EntityBase
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentNullException(nameof(name));

            var indexes = await (await _database.GetCollection<TEntity>(Collections[typeof(TEntity)]).Indexes
                .ListAsync()).ToListAsync();

            return indexes.SingleOrDefault(index => index.GetElement("name").Value.ToString() == name) != null;
        }

        public async Task CreateIndexKeyAsync<TEntity>(CreateIndexModel<TEntity> model) where TEntity : EntityBase
        {
            await _database.GetCollection<TEntity>(Collections[typeof(TEntity)]).Indexes.CreateOneAsync(model);
        }

        public async Task<bool> TryCreateIndexKeyAsync<TEntity>(CreateIndexModel<TEntity> model) where TEntity : 
            EntityBase
        {
            try
            {
                if (!await ContainsIndexKeyAsync<TEntity>(model.Options.Name)) await CreateIndexKeyAsync(model);
            }
            catch
            {
                return false;
            }

            return true;
        }
    }
}
