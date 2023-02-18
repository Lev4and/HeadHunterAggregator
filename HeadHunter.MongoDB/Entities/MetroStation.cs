using HeadHunter.Core.Domain;
using HeadHunter.Core.Specification;
using HeadHunter.MongoDB.Core.Abstracts;
using HeadHunter.MongoDB.Core.Domain;
using MongoDB.Bson.Serialization.Attributes;
using System.Linq.Expressions;

namespace HeadHunter.MongoDB.Entities
{
    public class MetroStation : MongoDBEntityBase, IAggregateRoot, IEqualSpecification<MetroStation>,
        IDefiningIndexKeys<MetroStation>
    {
        [BsonRequired]
        public Guid MetroLineId { get; set; }

        [BsonRequired]
        public string HeadHunterId { get; set; }

        [BsonRequired]
        public int Order { get; set; }

        [BsonRequired]
        public string Name { get; set; }

        [BsonRequired]
        public double Latitude { get; set; }

        [BsonRequired]
        public double Longitude { get; set; }

        public Expression<Func<MetroStation, bool>> IsEqual => (item) => item.HeadHunterId == HeadHunterId;

        public IEnumerable<Expression<Func<MetroStation, object>>> IndexKeys =>
            new List<Expression<Func<MetroStation, object>>>
        {
            item => item.MetroLineId, item => item.HeadHunterId, item => item.Order, item => item.Name,
            item => item.Latitude, item => item.Longitude
        };
    }
}
