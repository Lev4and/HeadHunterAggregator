using MongoDB.Bson.Serialization.Attributes;

namespace HeadHunter.Database.MongoDb.Collections
{
    public class LogoUrls
    {
        [BsonIgnoreIfNull]
        [BsonElement("_90px")]
        public string? _90px { get; set; }

        [BsonIgnoreIfNull]
        [BsonElement("_240px")]
        public string? _240px { get; set; }

        [BsonIgnoreIfNull]
        [BsonElement("original")]
        public string? Original { get; set; }
    }
}
