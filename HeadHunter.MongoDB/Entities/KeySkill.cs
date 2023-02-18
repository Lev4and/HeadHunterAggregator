using HeadHunter.Core.Domain;
using HeadHunter.Core.Specification;
using HeadHunter.MongoDB.Core.Abstracts;
using HeadHunter.MongoDB.Core.Domain;
using MongoDB.Bson.Serialization.Attributes;
using System.Linq.Expressions;

namespace HeadHunter.MongoDB.Entities
{
    public class KeySkill : MongoDBEntityBase, IAggregateRoot, IEqualSpecification<KeySkill>,
        IDefiningIndexKeys<KeySkill>
    {
        [BsonRequired]
        public string Name { get; set; }

        public Expression<Func<KeySkill, bool>> IsEqual => (item) => item.Name == Name;

        public IEnumerable<Expression<Func<KeySkill, object>>> IndexKeys =>
            new List<Expression<Func<KeySkill, object>>>
        {
            item => item.Name
        };
    }
}
