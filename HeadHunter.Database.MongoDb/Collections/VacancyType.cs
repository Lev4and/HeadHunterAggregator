using HeadHunter.Database.MongoDb.Common;
using HeadHunter.Database.MongoDb.Common.Attributes;
using HeadHunter.Database.MongoDb.Common.JsonConverters;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace HeadHunter.Database.MongoDb.Collections
{
    [MongoDbCollectionNameAttibute("vacancytypes")]
    public class VacancyType : ICollection
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

        public VacancyType()
        {

        }

        public VacancyType(Models.VacancyType vacancyType)
        {
            if (vacancyType == null)
            {
                throw new ArgumentNullException(nameof(vacancyType));
            }

            HeadHunterId = vacancyType.Id;
            Name = vacancyType.Name;
        }
    }
}
