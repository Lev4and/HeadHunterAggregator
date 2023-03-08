using HeadHunter.Core.Domain;
using HeadHunter.Core.Specification;
using HeadHunter.MongoDB.Abstracts;
using HeadHunter.MongoDB.Core.Abstracts;
using HeadHunter.MongoDB.Domain;
using MongoDB.Bson.Serialization.Attributes;
using System.Linq.Expressions;

namespace HeadHunter.MongoDB.Entities
{
    public class Contact : HeadHunterEntityBase, IAggregateRoot, IEqualSpecification<Contact>,
        IDefiningIndexKeys<Contact>
    {
        [BsonIgnoreIfNull]
        public string Name { get; set; }

        [BsonIgnoreIfNull]
        public string Email { get; set; }

        [BsonIgnoreIfNull]
        [BsonIgnoreIfDefault]
        public Guid[]? PhonesIds { get; set; }

        [BsonIgnore]
        public Phone[]? Phones { get; set; }

        public Expression<Func<Contact, bool>> IsEqual => (item) => item.Name == Name && item.Email == Email;

        public IEnumerable<Expression<Func<Contact, object>>> IndexKeys => new List<Expression<Func<Contact, object>>>
            {
                item => item.Name, item => item.Email, item => item.PhonesIds
            };

        public override async Task Accept(IImportVisitor visitor)
        {
            await visitor.Visit(this);
        }
    }
}
