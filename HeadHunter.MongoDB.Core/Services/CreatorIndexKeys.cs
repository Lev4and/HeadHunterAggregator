using HeadHunter.MongoDB.Core.Abstracts;
using HeadHunter.MongoDB.Core.Domain;
using MongoDB.Driver;

namespace HeadHunter.MongoDB.Core.Services
{
    public class CreatorIndexKeys : ICreatorIndexKeys
    {
        private readonly IMongoDbRepository _repository;

        public CreatorIndexKeys(IMongoDbRepository repository)
        {
            _repository = repository;
        }

        public async Task CreateAsync<TEntity>() where TEntity : MongoDbEntityBase, IDefiningIndexKeys<TEntity>
        {
            var entity = Activator.CreateInstance<TEntity>();

            foreach (var indexKey in entity.IndexKeys)
            {
                await _repository.CreateIndexKeyAsync(new CreateIndexModel<TEntity>(Builders<TEntity>
                    .IndexKeys.Ascending(indexKey)));
            }
        }
    }
}
