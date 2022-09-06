using HeadHunter.Database.MongoDb.Common;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace HeadHunter.Database.MongoDb.Collections
{
    public class Area : ICollection
    {
        [BsonId]
        public ObjectId Id { get; set; }

        [BsonElement("parentId")]
        public ObjectId? ParentId { get; set; }

        [BsonRequired]
        [BsonElement("headHunterId")]
        public string HeadHunterId { get; set; }

        [BsonIgnoreIfNull]
        [BsonElement("headHunterParentId")]
        public string? HeadHunterParentId { get; set; }

        [BsonRequired]
        [BsonElement("name")]
        public string? Name { get; set; }

        [BsonIgnoreIfNull]
        [BsonElement("url")]
        public string? Url { get; set; }

        [BsonIgnoreIfNull]
        [BsonElement("text")]
        public string? Text { get; set; }

        [BsonIgnoreIfNull]
        [BsonElement("metroLines")]
        public List<MetroLine> MetroLines { get; set; }
    }
}
