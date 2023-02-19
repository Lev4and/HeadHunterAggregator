using HeadHunter.Core.Domain;
using HeadHunter.Core.Specification;
using HeadHunter.MongoDB.Core.Abstracts;
using HeadHunter.MongoDB.Core.Domain;
using MongoDB.Bson.Serialization.Attributes;
using System.Linq.Expressions;

namespace HeadHunter.MongoDB.Entities
{
    public class InsiderInterview : MongoDbEntityBase, IAggregateRoot, IEqualSpecification<InsiderInterview>,
        IDefiningIndexKeys<InsiderInterview>
    {
        [BsonRequired]
        public string HeadHunterId { get; set; }

        [BsonRequired]
        public string Url { get; set; }

        public Expression<Func<InsiderInterview, bool>> IsEqual => (item) => item.HeadHunterId == HeadHunterId;

        public IEnumerable<Expression<Func<InsiderInterview, object>>> IndexKeys =>
            new List<Expression<Func<InsiderInterview, object>>>
        {
            item => item.HeadHunterId
        };
    }
}
