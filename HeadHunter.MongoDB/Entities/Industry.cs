using HeadHunter.Core.Domain;
using HeadHunter.Core.Specification;
using HeadHunter.MongoDB.Abstracts;
using HeadHunter.MongoDB.Core.Abstracts;
using HeadHunter.MongoDB.Domain;
using MongoDB.Bson.Serialization.Attributes;
using System.Linq.Expressions;

namespace HeadHunter.MongoDB.Entities
{
    public class Industry : HeadHunterEntityBase, IAggregateRoot, IEqualSpecification<Industry>,
        IDefiningIndexKeys<Industry>
    {
        [BsonIgnoreIfNull]
        public Guid? ParentId { get; set; }

        [BsonRequired]
        public string HeadHunterId { get; set; }

        [BsonRequired]
        public string Name { get; set; }

        [BsonIgnore]
        public Industry[]? Children { get; set; }

        public Expression<Func<Industry, bool>> IsEqual => (item) => item.HeadHunterId == HeadHunterId;

        public IEnumerable<Expression<Func<Industry, object>>> IndexKeys =>
            new List<Expression<Func<Industry, object>>>
        {
            item => item.ParentId, item => item.HeadHunterId, item => item.Name
        };

        public override async Task Accept(IImportVisitor visitor)
        {
            await visitor.Visit(this);
        }
    }
}
