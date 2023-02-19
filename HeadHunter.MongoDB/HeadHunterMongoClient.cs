using HeadHunter.MongoDB.Core;
using MongoDB.Driver;

namespace HeadHunter.MongoDB
{
    public class HeadHunterMongoClient : MongoClient
    {
        public HeadHunterMongoClient(): base($"mongodb://{MongoConfiguration.Username}:{MongoConfiguration.Password}@" +
            $"{MongoConfiguration.Host}:{MongoConfiguration.Port}/?authMechanism=SCRAM-SHA-256")
        {
            
        }

        public IMongoDatabase GetHeadHunterDb() 
        {
            return GetDatabase(MongoConfiguration.DatabaseName);
        }
    }
}
