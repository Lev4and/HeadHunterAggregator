﻿using HeadHunter.Core.Domain;
using HeadHunter.Core.Specification;
using HeadHunter.MongoDB.Core.Abstracts;
using HeadHunter.MongoDB.Core.Domain;
using MongoDB.Bson.Serialization.Attributes;
using System.Linq.Expressions;

namespace HeadHunter.MongoDB.Entities
{
    public class Currency : MongoDBEntityBase, IAggregateRoot, IEqualSpecification<Currency>, 
        IDefiningIndexKeys<Currency>
    {
        [BsonRequired]
        public string HeadHunterId { get; set; }

        public Expression<Func<Currency, bool>> IsEqual => (item) => item.HeadHunterId == HeadHunterId;

        public IEnumerable<Expression<Func<Currency, object>>> IndexKeys => new List<Expression<Func<Currency, object>>> 
        {
            item => item.HeadHunterId
        };
    }
}
