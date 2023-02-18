﻿using HeadHunter.Core.Domain;
using HeadHunter.Core.Specification;
using HeadHunter.MongoDB.Core.Abstracts;
using HeadHunter.MongoDB.Core.Domain;
using MongoDB.Bson.Serialization.Attributes;
using System.Linq.Expressions;

namespace HeadHunter.MongoDB.Entities
{
    public class Schedule : MongoDBEntityBase, IAggregateRoot, IEqualSpecification<Schedule>,
        IDefiningIndexKeys<Schedule>
    {
        [BsonRequired]
        public string HeadHunterId { get; set; }

        [BsonRequired]
        public string Name { get; set; }

        public Expression<Func<Schedule, bool>> IsEqual => (item) => item.HeadHunterId == HeadHunterId;

        public IEnumerable<Expression<Func<Schedule, object>>> IndexKeys =>
            new List<Expression<Func<Schedule, object>>>
        {
            item => item.HeadHunterId, item => item.Name
        };
    }
}
