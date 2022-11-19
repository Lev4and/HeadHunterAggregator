using HeadHunter.Database.MongoDb.Common;
using HeadHunter.Database.MongoDb.Common.Attributes;
using HeadHunter.Database.MongoDb.Common.JsonConverters;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace HeadHunter.Database.MongoDb.Collections
{
    [MongoDbCollectionNameAttibute("specializations")]
    public class Specialization : ICollection
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [JsonConverter(typeof(ObjectIdConverter))]
        public ObjectId Id { get; set; }

        [BsonIgnoreIfNull]
        [BsonElement("parentId")]
        [BsonRepresentation(BsonType.ObjectId)]
        [JsonConverter(typeof(ObjectIdConverter))]
        public ObjectId? ParentId { get; set; }

        [BsonIgnoreIfNull]
        [BsonElement("laboring")]
        public bool? Laboring { get; set; }

        [BsonRequired]
        [BsonElement("name")]
        public string Name { get; set; }

        [BsonIgnoreIfNull]
        [BsonElement("profareaId")]
        public string? ProfareaId { get; set; }

        [BsonRequired]
        [BsonElement("headHunterId")]
        public string HeadHunterId { get; set; }

        [BsonIgnoreIfNull]
        [BsonElement("headHunterParentId")]
        public string? HeadHunterParentId { get; set; }

        [BsonIgnoreIfNull]
        [BsonElement("profareaName")]
        public string? ProfareaName { get; set; }

        public Specialization? Parent { get; set; }

        public List<Specialization> Children { get; set; }

        public Specialization()
        {

        }

        public Specialization(Models.Specialization specialization)
        {
            if (specialization == null)
            {
                throw new ArgumentNullException(nameof(specialization));
            }

            Laboring = specialization.Laboring;
            Name = specialization.Name;
            ProfareaId = specialization.ProfareaId;
            HeadHunterId = specialization.Id;
            HeadHunterParentId = specialization.ParentId;
            HeadHunterParentId = specialization.Id.Contains('.') ? specialization.Id.Substring(0, specialization.Id.IndexOf('.')) : null;
            ProfareaName = specialization.ProfareaName;
        }
    }
}
