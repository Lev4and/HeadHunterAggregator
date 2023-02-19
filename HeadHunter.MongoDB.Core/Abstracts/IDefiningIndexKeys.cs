using HeadHunter.MongoDB.Core.Domain;
using MongoDB.Driver;
using System.Linq.Expressions;

namespace HeadHunter.MongoDB.Core.Abstracts
{
    public interface IDefiningIndexKeys<TCollection> where TCollection : MongoDbEntityBase
    {
        IEnumerable<Expression<Func<TCollection, object>>> IndexKeys { get; }
    }
}
