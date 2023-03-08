using HeadHunter.Core.Domain;
using HeadHunter.Core.Specification;
using HeadHunter.MongoDB.Abstracts;
using HeadHunter.MongoDB.Core.Abstracts;
using HeadHunter.MongoDB.Domain;
using MongoDB.Bson.Serialization.Attributes;
using System.Linq.Expressions;

namespace HeadHunter.MongoDB.Entities
{
    public class Address : HeadHunterEntityBase, IAggregateRoot, IEqualSpecification<Address>, IDefiningIndexKeys<Address>
    {
        [BsonRequired]
        public string City { get; set; }

        [BsonRequired]
        public string Street { get; set; }

        [BsonRequired]
        public string Building { get; set; }

        [BsonIgnoreIfNull]
        public string? Description { get; set; }

        [BsonRequired]
        public double? Latitude { get; set; }

        [BsonRequired]
        public double? Longitude { get; set; }

        public Expression<Func<Address, bool>> IsEqual => (item) => item.Latitude == Latitude && 
            item.Longitude == Longitude;

        public IEnumerable<Expression<Func<Address, object>>> IndexKeys => new List<Expression<Func<Address, object>>> 
        {
            item => item.City, item => item.Street, item => item.Building, item => item.Latitude, item => item.Longitude
        };

        public override async Task Accept(IImportVisitor visitor)
        {
            await visitor.Visit(this);
        }
    }
}
