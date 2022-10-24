using HeadHunter.Database.MongoDb.Common;
using HeadHunter.Database.MongoDb.Common.Attributes;
using HeadHunter.Database.MongoDb.Common.BsonSerializers;
using HeadHunter.Database.MongoDb.Common.JsonConverters;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace HeadHunter.Database.MongoDb.Collections
{
    [MongoDbCollectionNameAttibute("metrolines")]
    public class MetroLine : ICollection
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [JsonConverter(typeof(ObjectIdConverter))]
        public ObjectId Id { get; set; }

        [BsonIgnoreIfNull]
        [BsonElement("areaId")]
        [BsonRepresentation(BsonType.ObjectId)]
        [JsonConverter(typeof(ObjectIdConverter))]
        public ObjectId? AreaId { get; set; }

        [BsonRequired]
        [BsonElement("headHunterId")]
        public string HeadHunterId { get; set; }

        [BsonRequired]
        [BsonElement("name")]
        public string Name { get; set; }

        [BsonIgnoreIfNull]
        [BsonElement("cityId")]
        public string? CityId { get; set; }

        [BsonIgnoreIfNull]
        [BsonElement("hexColor")]
        public string? HexColor { get; set; }

        public Area? Area { get; set; }

        public List<MetroStation> Stations { get; set; }

        public MetroLine()
        {

        }

        public MetroLine(Models.MetroLine metroLine)
        {
            if (metroLine == null)
            {
                throw new ArgumentNullException(nameof(metroLine));
            }

            HeadHunterId = metroLine.Id;
            Name = metroLine.Name;
            CityId = metroLine.AreaId;
            HexColor = metroLine.HexColor;
            Area = metroLine.Area != null ? new Area(metroLine.Area) : null;
        }
    }
}
