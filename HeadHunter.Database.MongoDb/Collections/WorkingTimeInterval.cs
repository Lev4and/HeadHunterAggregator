using HeadHunter.Database.MongoDb.Common;
using HeadHunter.Database.MongoDb.Common.Attributes;
using HeadHunter.Database.MongoDb.Common.JsonConverters;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace HeadHunter.Database.MongoDb.Collections
{
    [MongoDbCollectionNameAttibute("workingtimeintervals")]
    public class WorkingTimeInterval : ICollection
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

        public WorkingTimeInterval()
        {

        }

        public WorkingTimeInterval(Models.WorkingTimeInterval workingTimeInterval)
        {
            if (workingTimeInterval == null)
            {
                throw new ArgumentNullException(nameof(workingTimeInterval));
            }

            HeadHunterId = workingTimeInterval.Id;
            Name = workingTimeInterval.Name;
        }
    }
}
