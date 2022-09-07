using HeadHunter.Database.MongoDb.Common.Attributes;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Linq.Expressions;

namespace HeadHunter.Database.MongoDb.Common
{
    public class Repository
    {
        private readonly IMongoDatabase _database;

        public Repository(IMongoDatabase database)
        {
            _database = database;
        }

        public Task SaveAsync<T>(T item) where T : ICollection
        {
            var options = new ReplaceOptions { IsUpsert = true };

            return GetCollection<T>().ReplaceOneAsync(element => element.Id == item.Id, item, options);
        }

        public Task<List<T>> FindAsync<T>() where T : ICollection
        {
            return GetCollection<T>().Find(item => true).ToListAsync();
        }

        public Task<List<T>> FindAsync<T>(Expression<Func<T, bool>> predicate) where T : ICollection
        {
            return GetCollection<T>().Find(predicate).ToListAsync();
        }

        public Task<T> FindByIdAsync<T>(ObjectId id) where T : ICollection
        {
            return GetCollection<T>().Find(item => item.Id == id).FirstOrDefaultAsync();
        }

        public Task RemoveAsync<T>(ObjectId id) where T : ICollection
        {
            return GetCollection<T>().DeleteOneAsync(item => item.Id == id);
        }

        private IMongoCollection<T> GetCollection<T>() => _database.GetCollection<T>((typeof(T)
            .GetCustomAttributes(typeof(MongoDbCollectionNameAttibute), true)[0] as MongoDbCollectionNameAttibute).Name);

    }
}
