using HeadHunter.Database.MongoDb.Common;
using HeadHunter.Database.MongoDb.Common.Attributes;
using HeadHunter.Database.MongoDb.Common.JsonConverters;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace HeadHunter.Database.MongoDb.Collections
{
    [MongoDbCollectionNameAttibute("billingtypes")]
    public class BillingType : ICollection
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [JsonConverter(typeof(ObjectIdConverter))]
        public ObjectId Id { get; set; }

        [BsonRequired]
        [BsonElement("headHunterId")]
        public string HeadHunterId { get; set; }

        [BsonRequired]
        [BsonElement("name")]
        public string Name { get; set; }

        public BillingType()
        {

        }

        public BillingType(Models.BillingType billingType)
        {
            if (billingType == null)
            {
                throw new ArgumentNullException(nameof(billingType));
            }

            HeadHunterId = billingType.Id;
            Name = billingType.Name;
        }
    }
}
