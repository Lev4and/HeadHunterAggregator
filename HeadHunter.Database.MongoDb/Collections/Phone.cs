using MongoDB.Bson.Serialization.Attributes;

namespace HeadHunter.Database.MongoDb.Collections
{
    public class Phone
    {
        [BsonIgnoreIfNull]
        [BsonElement("city")]
        public string? City { get; set; }

        [BsonIgnoreIfNull]
        [BsonElement("number")]
        public string? Number { get; set; }

        [BsonIgnoreIfNull]
        [BsonElement("country")]
        public string? Country { get; set; }

        [BsonIgnoreIfNull]
        [BsonElement("comment")]
        public object? Comment { get; set; }
    }
}
