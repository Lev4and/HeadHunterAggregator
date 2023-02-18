using HeadHunter.Core.Domain;
using HeadHunter.Core.Specification;
using HeadHunter.MongoDB.Core.Abstracts;
using HeadHunter.MongoDB.Core.Domain;
using MongoDB.Bson.Serialization.Attributes;
using System.Linq.Expressions;

namespace HeadHunter.MongoDB.Entities
{
    public class WorkingTimeMode : MongoDBEntityBase, IAggregateRoot, IEqualSpecification<WorkingTimeMode>,
        IDefiningIndexKeys<WorkingTimeMode>
    {
        [BsonRequired]
        public string HeadHunterId { get; set; }

        [BsonRequired]
        public string Name { get; set; }

        public Expression<Func<WorkingTimeMode, bool>> IsEqual => (item) => item.HeadHunterId == HeadHunterId;

        public IEnumerable<Expression<Func<WorkingTimeMode, object>>> IndexKeys =>
            new List<Expression<Func<WorkingTimeMode, object>>>
        {
            item => item.HeadHunterId, item => item.Name
        };
    }
}
