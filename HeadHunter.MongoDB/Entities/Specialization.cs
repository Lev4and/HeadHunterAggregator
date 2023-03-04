using HeadHunter.Core.Domain;
using HeadHunter.Core.Specification;
using HeadHunter.MongoDB.Core.Abstracts;
using HeadHunter.MongoDB.Domain;
using MongoDB.Bson.Serialization.Attributes;
using System.Linq.Expressions;

namespace HeadHunter.MongoDB.Entities
{
    public class Specialization : HeadHunterEntityBase, IAggregateRoot, IEqualSpecification<Specialization>,
        IDefiningIndexKeys<Specialization>
    {
        [BsonRequired]
        public string HeadHunterId { get; set; }

        [BsonRequired]
        public string Name { get; set; }

        public Specialization[]? Children { get; set; }

        public Expression<Func<Specialization, bool>> IsEqual => (item) => item.HeadHunterId == HeadHunterId;

        public IEnumerable<Expression<Func<Specialization, object>>> IndexKeys =>
            new List<Expression<Func<Specialization, object>>>
        {
            item => item.HeadHunterId, item => item.Name
        };
    }
}
