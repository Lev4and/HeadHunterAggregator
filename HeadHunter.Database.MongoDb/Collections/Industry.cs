using HeadHunter.Database.MongoDb.Common;
using HeadHunter.Database.MongoDb.Common.Attributes;
using HeadHunter.Database.MongoDb.Common.JsonConverters;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace HeadHunter.Database.MongoDb.Collections
{
    [MongoDbCollectionNameAttibute("industries")]
    public class Industry : ICollection
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

        [BsonRequired]
        [BsonElement("headHunterId")]
        public string HeadHunterId { get; set; }

        [BsonIgnoreIfNull]
        [BsonElement("headHunterParentId")]
        public string? HeadHunterParentId { get; set; }

        [BsonRequired]
        [BsonElement("name")]
        public string Name { get; set; }

        public Industry()
        {

        }

        public Industry(Models.Industry industry)
        {
            if (industry == null)
            {
                throw new ArgumentNullException(nameof(industry));
            }

            HeadHunterId = industry.Id;
            HeadHunterParentId = industry.Id.Contains('.') ? industry.Id.Substring(0, industry.Id.LastIndexOf('.')) : null;
            Name = industry.Name;
        }
    }
}
