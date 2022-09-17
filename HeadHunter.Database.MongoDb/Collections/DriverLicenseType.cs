using HeadHunter.Database.MongoDb.Common;
using HeadHunter.Database.MongoDb.Common.Attributes;
using HeadHunter.Database.MongoDb.Common.JsonConverters;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace HeadHunter.Database.MongoDb.Collections
{
    [MongoDbCollectionNameAttibute("driverlicensetypes")]
    public class DriverLicenseType : ICollection
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [JsonConverter(typeof(ObjectIdConverter))]
        public ObjectId Id { get; set; }

        [BsonRequired]
        [BsonElement("headHunterId")]
        public string HeadHunterId { get; set; }

        public DriverLicenseType()
        {

        }

        public DriverLicenseType(Models.DriverLicenseType driverLicenseType)
        {
            if (driverLicenseType == null)
            {
                throw new ArgumentNullException(nameof(driverLicenseType));
            }

            HeadHunterId = driverLicenseType.Id;
        }
    }
}
