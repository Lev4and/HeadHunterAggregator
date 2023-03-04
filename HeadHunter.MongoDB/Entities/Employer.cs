using HeadHunter.Core.Domain;
using HeadHunter.Core.Specification;
using HeadHunter.MongoDB.Core.Abstracts;
using HeadHunter.MongoDB.Domain;
using MongoDB.Bson.Serialization.Attributes;
using System.Linq.Expressions;

namespace HeadHunter.MongoDB.Entities
{
    public class Employer : HeadHunterEntityBase, IAggregateRoot, IEqualSpecification<Employer>,
        IDefiningIndexKeys<Employer>
    {
        [BsonIgnoreIfNull]
        public Guid? AreaId { get; set; }

        [BsonIgnoreIfNull]
        public bool? Trusted { get; set; }

        [BsonIgnoreIfNull]
        public bool? Blacklisted { get; set; }

        [BsonRequired]
        public long HeadHunterId { get; set; }

        [BsonRequired]
        public string Name { get; set; }

        [BsonIgnoreIfNull]
        public string? Url { get; set; }

        [BsonIgnoreIfNull]
        public string? Type { get; set; }

        [BsonIgnoreIfNull]
        public string? SiteUrl { get; set; }

        [BsonIgnoreIfNull]
        public string? Description { get; set; }

        [BsonIgnoreIfNull]
        public string? AlternateUrl { get; set; }

        [BsonIgnoreIfNull]
        public string? VacanciesUrl { get; set; }

        [BsonIgnoreIfNull]
        public string? BrandedDescription { get; set; }

        public Area? Area { get; set; }

        [BsonIgnoreIfNull]
        public EmployerLogo? Logo { get; set; }

        [BsonIgnoreIfNull]
        public Guid[]? IndustriesIds { get; set; }

        [BsonIgnoreIfNull]
        public Guid[]? InsiderInterviewsIds { get; set; }

        public Industry[]? Industries { get; set; }

        public InsiderInterview[]? InsiderInterviews { get; set; }

        public Expression<Func<Employer, bool>> IsEqual => (item) => item.HeadHunterId == HeadHunterId;

        public IEnumerable<Expression<Func<Employer, object>>> IndexKeys => new List<Expression<Func<Employer, object>>>
        {
            item => item.AreaId, item => item.Trusted, item => item.Blacklisted, item => item.HeadHunterId, 
            item => item.Name, item => item.Type, item => item.IndustriesIds, item => item.InsiderInterviewsIds
        };
    }
}
