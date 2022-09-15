using HeadHunter.Database.MongoDb.Common;
using HeadHunter.Database.MongoDb.Common.Attributes;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace HeadHunter.Database.MongoDb.Collections
{
    [MongoDbCollectionNameAttibute("specializations")]
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
            ProfareaName = specialization.ProfareaName;
        }
    }
}
