using HeadHunter.Core.Domain;
using HeadHunter.Core.Specification;
using HeadHunter.MongoDB.Core.Domain;
using MongoDB.Bson.Serialization.Attributes;
using System.Linq.Expressions;

namespace HeadHunter.MongoDB.Entities
{
    public class Test : MongoDBEntityBase, IAggregateRoot, IEqualSpecification<Test>
    {
        [BsonRequired]
        public string HeadHunterId { get; set; }

        [BsonRequired]
        public string Name { get; set; }

        public Expression<Func<Test, bool>> IsEqual => (item) => item.HeadHunterId == HeadHunterId;

        public IEnumerable<Expression<Func<Test, object>>> IndexKeys =>
            new List<Expression<Func<Test, object>>>
        {
            item => item.HeadHunterId, item => item.Name
        };
    }
}
