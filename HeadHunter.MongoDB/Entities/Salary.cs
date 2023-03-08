using MongoDB.Bson.Serialization.Attributes;

namespace HeadHunter.MongoDB.Entities
{
    public class Salary
    {
        [BsonIgnoreIfNull]
        public Guid? CurrencyId { get; set; }

        [BsonIgnoreIfNull]
        public bool? Gross { get; set; }

        [BsonIgnoreIfNull]
        public decimal? To { get; set; }

        [BsonIgnoreIfNull]
        public decimal? From { get; set; }

        [BsonIgnore]
        public Currency? Currency { get; set; }
    }
}
