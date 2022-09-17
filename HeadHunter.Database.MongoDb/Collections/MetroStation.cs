using HeadHunter.Database.MongoDb.Common;
using HeadHunter.Database.MongoDb.Common.Attributes;
using HeadHunter.Database.MongoDb.Common.JsonConverters;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace HeadHunter.Database.MongoDb.Collections
{
    [MongoDbCollectionNameAttibute("metrostations")]
    public class MetroStation : ICollection
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [JsonConverter(typeof(ObjectIdConverter))]
        public ObjectId Id { get; set; }

        [BsonIgnoreIfNull]
        [BsonElement("metroLineId")]
        [BsonRepresentation(BsonType.ObjectId)]
        [JsonConverter(typeof(ObjectIdConverter))]
        public ObjectId? MetroLineId { get; set; }

        [BsonRequired]
        [BsonElement("headHunterId")]
        public string HeadHunterId { get; set; }

        [BsonIgnoreIfNull]
        [BsonElement("order")]
        public int? Order { get; set; }

        [BsonRequired]
        [BsonElement("name")]
        public string Name { get; set; }

        [BsonIgnoreIfNull]
        [BsonElement("lineId")]
        public string? LineId { get; set; }

        [BsonIgnoreIfNull]
        [BsonElement("lineName")]
        public string? LineName { get; set; }

        [BsonIgnoreIfNull]
        [BsonElement("stationId")]
        public string StationId { get; set; }

        [BsonIgnoreIfNull]
        [BsonElement("stationName")]
        public string StationName { get; set; }

        [BsonIgnoreIfNull]
        [BsonElement("latitude")]
        public double? Latitude { get; set; }

        [BsonIgnoreIfNull]
        [BsonElement("longitude")]
        public double? Longitude { get; set; }

        public MetroStation()
        {

        }

        public MetroStation(Models.MetroStation metroStation)
        {
            if (metroStation == null)
            {
                throw new ArgumentNullException(nameof(metroStation));
            }

            HeadHunterId = metroStation.Id;
            Order = metroStation.Order;
            Name = metroStation.Name;
            LineId = metroStation.LineId;
            LineName = metroStation.LineName;
            StationId = metroStation.StationId;
            StationName = metroStation.StationName;
            Latitude = metroStation.Lat;
            Longitude = metroStation.Lng;
        }
    }
}
