using HeadHunter.Database.MongoDb.Common;
using HeadHunter.Database.MongoDb.Common.Attributes;
using HeadHunter.Database.MongoDb.Common.JsonConverters;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace HeadHunter.Database.MongoDb.Collections
{
    [MongoDbCollectionNameAttibute("areas")]
    public class Area : ICollection
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [JsonConverter(typeof(ObjectIdConverter))]
        public ObjectId Id { get; set; }

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
        public string? Name { get; set; }

        [BsonIgnoreIfNull]
        [BsonElement("url")]
        public string? Url { get; set; }

        [BsonIgnoreIfNull]
        [BsonElement("text")]
        public string? Text { get; set; }

        public Area()
        {

        }

        public Area(Models.Area area)
        {
            if (area == null)
            {
                throw new ArgumentNullException(nameof(area));
            }

            HeadHunterId = area.Id;
            HeadHunterParentId = area.ParentId;
            Name = area.Name;
            Url = area.Url;
            Text = area.Text;
        }
    }
}
