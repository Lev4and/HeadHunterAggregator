using HeadHunter.Core.Domain;
using HeadHunter.Core.Specification;
using HeadHunter.MongoDB.Core.Abstracts;
using HeadHunter.MongoDB.Core.Domain;
using MongoDB.Bson.Serialization.Attributes;
using System.Linq.Expressions;

namespace HeadHunter.MongoDB.Entities
{
    public class Department : MongoDBEntityBase, IAggregateRoot, IEqualSpecification<Department>,
        IDefiningIndexKeys<Department>
    {
        [BsonRequired]
        public string HeadHunterId { get; set; }

        [BsonRequired]
        public string Name { get; set; }

        public Expression<Func<Department, bool>> IsEqual => (item) => item.HeadHunterId == HeadHunterId;

        public IEnumerable<Expression<Func<Department, object>>> IndexKeys => 
            new List<Expression<Func<Department, object>>>
        {
            item => item.HeadHunterId, item => item.Name
        };
    }
}
