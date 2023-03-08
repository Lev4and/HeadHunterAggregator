using HeadHunter.Core.Domain;
using HeadHunter.Core.Specification;
using HeadHunter.MongoDB.Abstracts;
using HeadHunter.MongoDB.Core.Abstracts;
using HeadHunter.MongoDB.Domain;
using MongoDB.Bson.Serialization.Attributes;
using System.Linq.Expressions;

namespace HeadHunter.MongoDB.Entities
{
    public class Phone : HeadHunterEntityBase, IAggregateRoot, IEqualSpecification<Phone>,
        IDefiningIndexKeys<Phone>
    {
        [BsonIgnoreIfNull]
        public string? City { get; set; }

        [BsonRequired]
        public string Number { get; set; }

        [BsonIgnoreIfNull]
        public string? Country { get; set; }

        [BsonIgnoreIfNull]
        public string? Comment { get; set; }

        public Expression<Func<Phone, bool>> IsEqual => (item) => item.Number == Number;

        public IEnumerable<Expression<Func<Phone, object>>> IndexKeys =>
            new List<Expression<Func<Phone, object>>>
        {
            item => item.City, item => item.Number, item => item.Country
        };

        public override async Task Accept(IImportVisitor visitor)
        {
            await visitor.Visit(this);
        }
    }
}
