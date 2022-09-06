using MongoDB.Bson.Serialization.Attributes;

namespace HeadHunter.Database.MongoDb.Collections
{
    public class Salary
    {
        [BsonIgnoreIfNull]
        [BsonElement("gross")]
        public bool? Gross { get; set; }

        [BsonIgnoreIfNull]
        [BsonElement("to")]
        public decimal? To { get; set; }

        [BsonIgnoreIfNull]
        [BsonElement("from")]
        public decimal? From { get; set; }

        [BsonIgnoreIfNull]
        [BsonElement("currency")]
        public Currency? Currency { get; set; }
    }
}
