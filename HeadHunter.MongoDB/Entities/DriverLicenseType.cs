using HeadHunter.Core.Domain;
using HeadHunter.Core.Specification;
using HeadHunter.MongoDB.Core.Abstracts;
using HeadHunter.MongoDB.Core.Domain;
using MongoDB.Bson.Serialization.Attributes;
using System.Linq.Expressions;

namespace HeadHunter.MongoDB.Entities
{
    public class DriverLicenseType : MongoDBEntityBase, IAggregateRoot, IEqualSpecification<DriverLicenseType>,
        IDefiningIndexKeys<DriverLicenseType>
    {
        [BsonRequired]
        public string HeadHunterId { get; set; }

        public Expression<Func<DriverLicenseType, bool>> IsEqual => throw new NotImplementedException();

        public IEnumerable<Expression<Func<DriverLicenseType, object>>> IndexKeys =>
            new List<Expression<Func<DriverLicenseType, object>>>
        {
            item => item.HeadHunterId
        };
    }
}
