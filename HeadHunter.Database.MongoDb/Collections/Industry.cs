using HeadHunter.Database.MongoDb.Common;
using HeadHunter.Database.MongoDb.Common.Attributes;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace HeadHunter.Database.MongoDb.Collections
{
    [MongoDbCollectionNameAttibute("industries")]
    public class Industry : ICollection
    {
        [BsonId]
        public ObjectId Id { get; set; }

        [BsonIgnoreIfNull]
        [BsonElement("parentId")]
        public ObjectId? ParentId { get; set; }

        [BsonRequired]
        [BsonElement("headHunterId")]
        public string HeadHunterId { get; set; }

        [BsonRequired]
        [BsonElement("name")]
        public string Name { get; set; }
    }
}
