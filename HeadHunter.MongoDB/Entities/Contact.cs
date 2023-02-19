﻿using HeadHunter.Core.Domain;
using HeadHunter.Core.Specification;
using HeadHunter.MongoDB.Core.Abstracts;
using HeadHunter.MongoDB.Core.Domain;
using MongoDB.Bson.Serialization.Attributes;
using System.Linq.Expressions;

namespace HeadHunter.MongoDB.Entities
{
    public class Contact : MongoDbEntityBase, IAggregateRoot, IEqualSpecification<Contact>,
        IDefiningIndexKeys<Contact>
    {
        [BsonIgnoreIfNull]
        public string Name { get; set; }

        [BsonIgnoreIfNull]
        public string Email { get; set; }

        [BsonIgnoreIfNull]
        public Guid[]? PhonesIds { get; set; }

        public Expression<Func<Contact, bool>> IsEqual => (item) => item.Name == Name && item.Email == Email;

        public IEnumerable<Expression<Func<Contact, object>>> IndexKeys => new List<Expression<Func<Contact, object>>>
            {
                item => item.Name, item => item.Email, item => item.PhonesIds
            };
    }
}
