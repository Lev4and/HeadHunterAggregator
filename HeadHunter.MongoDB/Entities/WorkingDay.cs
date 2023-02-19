using HeadHunter.Core.Domain;
using HeadHunter.Core.Specification;
using HeadHunter.MongoDB.Core.Abstracts;
using HeadHunter.MongoDB.Core.Domain;
using MongoDB.Bson.Serialization.Attributes;
using System.Linq.Expressions;

namespace HeadHunter.MongoDB.Entities
{
    public class WorkingDay : MongoDbEntityBase, IAggregateRoot, IEqualSpecification<WorkingDay>,
        IDefiningIndexKeys<WorkingDay>
    {
        [BsonRequired]
        public string HeadHunterId { get; set; }

        [BsonRequired]
        public string Name { get; set; }

        public Expression<Func<WorkingDay, bool>> IsEqual => (item) => item.HeadHunterId == HeadHunterId;

        public IEnumerable<Expression<Func<WorkingDay, object>>> IndexKeys =>
            new List<Expression<Func<WorkingDay, object>>>
        {
            item => item.HeadHunterId, item => item.Name
        };
    }
}
