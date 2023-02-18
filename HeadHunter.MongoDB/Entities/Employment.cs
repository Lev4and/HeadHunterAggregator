using HeadHunter.Core.Domain;
using HeadHunter.Core.Specification;
using HeadHunter.MongoDB.Core.Abstracts;
using HeadHunter.MongoDB.Core.Domain;
using MongoDB.Bson.Serialization.Attributes;
using System.Linq.Expressions;

namespace HeadHunter.MongoDB.Entities
{
    public class Employment : MongoDBEntityBase, IAggregateRoot, IEqualSpecification<Employment>,
        IDefiningIndexKeys<Employment>
    {
        [BsonRequired]
        public string HeadHunterId { get; set; }

        [BsonRequired]
        public string Name { get; set; }

        public Expression<Func<Employment, bool>> IsEqual => (item) => item.HeadHunterId == HeadHunterId;

        public IEnumerable<Expression<Func<Employment, object>>> IndexKeys =>
            new List<Expression<Func<Employment, object>>>
        {
            item => item.HeadHunterId, item => item.Name
        };
    }
}
