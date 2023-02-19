using HeadHunter.Core.Domain;
using HeadHunter.Core.Specification;
using HeadHunter.MongoDB.Core.Abstracts;
using HeadHunter.MongoDB.Core.Domain;
using MongoDB.Bson.Serialization.Attributes;
using System.Linq.Expressions;

namespace HeadHunter.MongoDB.Entities
{
    public class MetroLine : MongoDbEntityBase, IAggregateRoot, IEqualSpecification<MetroLine>,
        IDefiningIndexKeys<MetroLine>
    {
        [BsonRequired]
        public Guid AreaId { get; set; }

        [BsonRequired]
        public string HeadHunterId { get; set; }

        [BsonRequired]
        public string Name { get; set; }

        [BsonIgnoreIfNull]
        public string? HexColor { get; set; }

        public Expression<Func<MetroLine, bool>> IsEqual => (item) => item.HeadHunterId == HeadHunterId;

        public IEnumerable<Expression<Func<MetroLine, object>>> IndexKeys =>
            new List<Expression<Func<MetroLine, object>>>
        {
            item => item.AreaId, item => item.HeadHunterId, item => item.Name
        };
    }
}
