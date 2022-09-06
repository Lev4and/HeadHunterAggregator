using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace HeadHunter.Database.MongoDb.Common
{
    public interface ICollection
    {
        [BsonId]
        public ObjectId Id { get; set; }
    }
}
