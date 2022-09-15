using HeadHunter.Database.MongoDb.Common;
using HeadHunter.Database.MongoDb.Common.Attributes;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace HeadHunter.Database.MongoDb.Collections
{
    [MongoDbCollectionNameAttibute("professionalroles")]
    public class ProfessionalRole : ICollection
    {
        [BsonId]
        public ObjectId Id { get; set; }

        [BsonRequired]
        [BsonElement("headHunterId")]
        public string HeadHunterId { get; set; }

        [BsonRequired]
        [BsonElement("name")]
        public string Name { get; set; }

        public ProfessionalRole(Models.ProfessionalRole professionalRole)
        {
            if (professionalRole == null)
            {
                throw new ArgumentNullException(nameof(professionalRole));
            }

            HeadHunterId = professionalRole.Id;
            Name = professionalRole.Name;
        }
    }
}
