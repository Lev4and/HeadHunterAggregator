using MongoDB.Bson.Serialization.Attributes;

namespace HeadHunter.Database.MongoDb.Collections
{
    public class Contacts
    {
        [BsonIgnoreIfNull]
        [BsonElement("name")]
        public string? Name { get; set; }

        [BsonIgnoreIfNull]
        [BsonElement("email")]
        public string? Email { get; set; }

        [BsonIgnoreIfNull]
        [BsonElement("phones")]
        public List<Phone> Phones { get; set; }
    }
}
