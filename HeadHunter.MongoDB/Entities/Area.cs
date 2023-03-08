using HeadHunter.Core.Domain;
using HeadHunter.Core.Specification;
using HeadHunter.MongoDB.Abstracts;
using HeadHunter.MongoDB.Core.Abstracts;
using HeadHunter.MongoDB.Domain;
using MongoDB.Bson.Serialization.Attributes;
using System.Linq.Expressions;

namespace HeadHunter.MongoDB.Entities
{
    public class Area : HeadHunterEntityBase, IAggregateRoot, IEqualSpecification<Area>, IDefiningIndexKeys<Area>
    {
        [BsonIgnoreIfNull]
        public Guid? ParentId { get; set; }

        [BsonRequired]
        public string HeadHunterId { get; set; }

        [BsonRequired]
        public string Name { get; set; }

        [BsonIgnore]
        public Area[]? Children { get; set; }

        public Expression<Func<Area, bool>> IsEqual => (item) => item.HeadHunterId == HeadHunterId;

        public IEnumerable<Expression<Func<Area, object>>> IndexKeys => new List<Expression<Func<Area, object>>> 
        {
            item => item.ParentId, item => item.HeadHunterId, item => item.Name
        };

        public override async Task Accept(IImportVisitor visitor)
        {
            await visitor.Visit(this);
        }
    }
}
