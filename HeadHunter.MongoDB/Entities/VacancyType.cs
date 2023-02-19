using HeadHunter.Core.Domain;
using HeadHunter.Core.Specification;
using HeadHunter.MongoDB.Core.Abstracts;
using HeadHunter.MongoDB.Core.Domain;
using MongoDB.Bson.Serialization.Attributes;
using System.Linq.Expressions;

namespace HeadHunter.MongoDB.Entities
{
    public class VacancyType : MongoDbEntityBase, IAggregateRoot, IEqualSpecification<VacancyType>,
        IDefiningIndexKeys<VacancyType>
    {
        [BsonRequired]
        public string HeadHunterId { get; set; }

        [BsonRequired]
        public string Name { get; set; }

        public Expression<Func<VacancyType, bool>> IsEqual => (item) => item.HeadHunterId == HeadHunterId;

        public IEnumerable<Expression<Func<VacancyType, object>>> IndexKeys =>
            new List<Expression<Func<VacancyType, object>>>
        {
            item => item.HeadHunterId, item => item.Name
        };
    }
}
