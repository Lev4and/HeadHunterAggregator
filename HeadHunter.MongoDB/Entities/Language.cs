using HeadHunter.Core.Domain;
using HeadHunter.Core.Specification;
using HeadHunter.MongoDB.Core.Abstracts;
using HeadHunter.MongoDB.Domain;
using MongoDB.Bson.Serialization.Attributes;
using System.Linq.Expressions;

namespace HeadHunter.MongoDB.Entities
{
    public class Language : HeadHunterEntityBase, IAggregateRoot, IEqualSpecification<Language>,
        IDefiningIndexKeys<Language>
    {
        [BsonRequired]
        public string HeadHunterId { get; set; }

        [BsonRequired]
        public string Name { get; set; }

        public Expression<Func<Language, bool>> IsEqual => (item) => item.HeadHunterId == HeadHunterId;

        public IEnumerable<Expression<Func<Language, object>>> IndexKeys =>
            new List<Expression<Func<Language, object>>>
        {
            item => item.HeadHunterId, item => item.Name
        };
    }
}
