﻿using HeadHunter.Core.Domain;
using HeadHunter.Core.Specification;
using HeadHunter.MongoDB.Core.Abstracts;
using HeadHunter.MongoDB.Core.Domain;
using MongoDB.Bson.Serialization.Attributes;
using System.Linq.Expressions;

namespace HeadHunter.MongoDB.Entities
{
    public class BillingType : MongoDBEntityBase, IAggregateRoot, IEqualSpecification<BillingType>, 
        IDefiningIndexKeys<BillingType>
    {
        [BsonRequired]
        public string HeadHunterId { get; set; }

        [BsonRequired]
        public string Name { get; set; }

        public Expression<Func<BillingType, bool>> IsEqual => (item) => item.HeadHunterId == HeadHunterId;

        public IEnumerable<Expression<Func<BillingType, object>>> IndexKeys => 
            new List<Expression<Func<BillingType, object>>>
            {
                item => item.HeadHunterId, item => item.Name
            };
    }
}
