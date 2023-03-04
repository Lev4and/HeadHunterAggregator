using HeadHunter.Core.Domain;
using HeadHunter.Core.Specification;
using HeadHunter.MongoDB.Core.Abstracts;
using HeadHunter.MongoDB.Domain;
using MongoDB.Bson.Serialization.Attributes;
using System.Linq.Expressions;

namespace HeadHunter.MongoDB.Entities
{
    public class WorkingTimeInterval : HeadHunterEntityBase, IAggregateRoot, IEqualSpecification<WorkingTimeInterval>,
        IDefiningIndexKeys<WorkingTimeInterval>
    {
        [BsonRequired]
        public string HeadHunterId { get; set; }

        [BsonRequired]
        public string Name { get; set; }

        public Expression<Func<WorkingTimeInterval, bool>> IsEqual => (item) => item.HeadHunterId == HeadHunterId;

        public IEnumerable<Expression<Func<WorkingTimeInterval, object>>> IndexKeys =>
            new List<Expression<Func<WorkingTimeInterval, object>>>
        {
            item => item.HeadHunterId, item => item.Name
        };
    }
}
