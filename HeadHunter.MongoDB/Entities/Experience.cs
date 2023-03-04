using HeadHunter.Core.Domain;
using HeadHunter.Core.Specification;
using HeadHunter.MongoDB.Core.Abstracts;
using HeadHunter.MongoDB.Domain;
using MongoDB.Bson.Serialization.Attributes;
using System.Linq.Expressions;

namespace HeadHunter.MongoDB.Entities
{
    public class Experience : HeadHunterEntityBase, IAggregateRoot, IEqualSpecification<Experience>,
        IDefiningIndexKeys<Experience>
    {
        [BsonRequired]
        public string HeadHunterId { get; set; }

        [BsonRequired]
        public string Name { get; set; }

        public Expression<Func<Experience, bool>> IsEqual => (item) => item.HeadHunterId == HeadHunterId;

        public IEnumerable<Expression<Func<Experience, object>>> IndexKeys =>
            new List<Expression<Func<Experience, object>>>
        {
            item => item.HeadHunterId, item => item.Name
        };
    }
}
