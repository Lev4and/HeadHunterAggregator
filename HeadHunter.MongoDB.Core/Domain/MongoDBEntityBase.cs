using HeadHunter.Core.Domain;
using MongoDB.Bson.Serialization.Attributes;

namespace HeadHunter.MongoDB.Core.Domain
{
    public class MongoDBEntityBase : EntityBase
    {
        [BsonId]
        [BsonRequired]
        public override Guid Id { get => base.Id; set => base.Id = value; }
    }
}
