using MongoDB.Bson.Serialization.Attributes;

namespace HeadHunter.MongoDB.Entities
{
    public class EmployerLogo
    {
        [BsonIgnoreIfNull]
        public string? Small { get; set; }

        [BsonIgnoreIfNull]
        public string? Normal { get; set; }

        [BsonIgnoreIfNull]
        public string? Original { get; set; }
    }
}
