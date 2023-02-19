using HeadHunter.MongoDB.Core.Domain;

namespace HeadHunter.MongoDB.Core.Abstracts
{
    public interface ICreatorIndexKeys
    {
        Task CreateAsync<TEntity>() where TEntity : MongoDbEntityBase, IDefiningIndexKeys<TEntity>;
    }
}
