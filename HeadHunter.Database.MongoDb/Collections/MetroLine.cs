using HeadHunter.Database.MongoDb.Common;
using HeadHunter.Database.MongoDb.Common.Attributes;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace HeadHunter.Database.MongoDb.Collections
{
    [MongoDbCollectionNameAttibute("metrolines")]
    public class MetroLine : ICollection
    {
        [BsonId]
        public ObjectId Id { get; set; }

        [BsonRequired]
        [BsonElement("headHunterId")]
        public string HeadHunterId { get; set; }

        [BsonRequired]
        [BsonElement("name")]
        public string Name { get; set; }

        [BsonIgnoreIfNull]
        [BsonElement("hexColor")]
        public string? HexColor { get; set; }

        public MetroLine(Models.MetroLine metroLine)
        {
            if (metroLine == null)
            {
                throw new ArgumentNullException(nameof(metroLine));
            }

            HeadHunterId = metroLine.Id;
            Name = metroLine.Name;
            HexColor = metroLine.HexColor;
        }
    }
}
