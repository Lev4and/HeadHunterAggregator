﻿using HeadHunter.Core.Domain;
using HeadHunter.Core.Specification;
using HeadHunter.MongoDB.Core.Abstracts;
using HeadHunter.MongoDB.Core.Domain;
using MongoDB.Bson.Serialization.Attributes;
using System.Linq.Expressions;

namespace HeadHunter.MongoDB.Entities
{
    public class ProfessionalRole : MongoDBEntityBase, IAggregateRoot, IEqualSpecification<ProfessionalRole>,
        IDefiningIndexKeys<ProfessionalRole>
    {
        [BsonRequired]
        public string HeadHunterId { get; set; }

        [BsonRequired]
        public string Name { get; set; }

        public Expression<Func<ProfessionalRole, bool>> IsEqual => (item) => item.HeadHunterId == HeadHunterId;

        public IEnumerable<Expression<Func<ProfessionalRole, object>>> IndexKeys =>
            new List<Expression<Func<ProfessionalRole, object>>>
        {
            item => item.HeadHunterId, item => item.Name
        };
    }
}
