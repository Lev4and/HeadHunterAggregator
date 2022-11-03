using MongoDB.Driver;
using System.Linq.Expressions;

namespace HeadHunter.Database.MongoDb.Common
{
    public static class CreatorCreateIndexModel
    {
        public static IEnumerable<CreateIndexModel<TCollection>> Create<TCollection>(Expression<Func<TCollection, object>>[] fields) where TCollection : ICollection
        {
            var result = new List<CreateIndexModel<TCollection>>();

            foreach (var field in fields)
            {
                result.Add(new CreateIndexModel<TCollection>(Builders<TCollection>.IndexKeys.Ascending(field)));
            }

            return result;
        }
    }
}
