using HeadHunter.Core.Domain;
using HeadHunter.Core.Repository;
using MongoDB.Driver;

namespace HeadHunter.MongoDB.Core
{
    public interface IMongoDbRepository : IRepository, IGridRepository
    {
        Dictionary<Type, string> Collections { get; }

        Task<bool> ContainsIndexKeyAsync<TEntity>(string name) where TEntity : EntityBase;

        Task CreateIndexKeyAsync<TEntity>(CreateIndexModel<TEntity> model) where TEntity : EntityBase;

        Task<bool> TryCreateIndexKeyAsync<TEntity>(CreateIndexModel<TEntity> model) where TEntity : EntityBase;
    }
}
