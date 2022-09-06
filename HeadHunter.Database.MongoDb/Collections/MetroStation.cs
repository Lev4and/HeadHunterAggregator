using HeadHunter.Database.MongoDb.Common;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace HeadHunter.Database.MongoDb.Collections
{
    public class MetroStation : ICollection
    {
        [BsonId]
        public ObjectId Id { get; set; }

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
    }
}
