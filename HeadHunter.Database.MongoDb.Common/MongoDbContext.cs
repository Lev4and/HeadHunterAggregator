using MongoDB.Driver;

namespace HeadHunter.Database.MongoDb.Common
{
    public class MongoDbContext
    {
        private readonly MongoClient _client;

        public MongoDbContext()
        {
            _client = new MongoClient("mongodb://sa:sa@lev4and.ru:27017/?authMechanism=DEFAULT");
        }

        public IMongoDatabase GetDatabase(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException(nameof(name));
            }

            return _client.GetDatabase(name);
        }
    }
}
