using HeadHunter.Database.MongoDb.Common;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace HeadHunter.Database.MongoDb.Collections
{
    public class Specialization : ICollection
    {
        [BsonId]
        public ObjectId Id { get; set; }

        [BsonIgnoreIfNull]
        [BsonElement("parentId")]
        public ObjectId? ParentId { get; set; }

        [BsonIgnoreIfNull]
        [BsonElement("laboring")]
        public bool? Laboring { get; set; }

        [BsonRequired]
        [BsonElement("name")]
        public string Name { get; set; }

        [BsonIgnoreIfNull]
        [BsonElement("text")]
        public string Text { get; set; }

        [BsonIgnoreIfNull]
        [BsonElement("profareaId")]
        public string ProfareaId { get; set; }

        [BsonRequired]
        [BsonElement("headHunterId")]
        public string HeadHunterId { get; set; }

        [BsonIgnoreIfNull]
        [BsonElement("profareaName")]
        public string ProfareaName { get; set; }
    }
}
