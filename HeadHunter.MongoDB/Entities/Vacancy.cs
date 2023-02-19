using HeadHunter.Core.Domain;
using HeadHunter.Core.Specification;
using HeadHunter.MongoDB.Core.Abstracts;
using HeadHunter.MongoDB.Core.Domain;
using MongoDB.Bson.Serialization.Attributes;
using System.Linq.Expressions;

namespace HeadHunter.MongoDB.Entities
{
    public class Vacancy : MongoDbEntityBase, IAggregateRoot, IEqualSpecification<Vacancy>,
        IDefiningIndexKeys<Vacancy>
    {
        [BsonIgnoreIfNull]
        public Guid? AreaId { get; set; }

        [BsonIgnoreIfNull]
        public Guid? TestId { get; set; }

        [BsonIgnoreIfNull]
        public Guid? AddressId { get; set; }

        [BsonIgnoreIfNull]
        public Guid? ContactId { get; set; }

        [BsonIgnoreIfNull]
        public Guid? EmployerId { get; set; }

        [BsonIgnoreIfNull]
        public Guid? ScheduleId { get; set; }

        [BsonIgnoreIfNull]
        public Guid? ExperienceId { get; set; }

        [BsonIgnoreIfNull]
        public Guid? EmploymentId { get; set; }

        [BsonIgnoreIfNull]
        public Guid? DepartmentId { get; set; }

        [BsonIgnoreIfNull]
        public Guid? VacancyTypeId { get; set; }

        [BsonIgnoreIfNull]
        public Guid? BillingTypeId { get; set; }

        [BsonIgnoreIfNull]
        public Guid? InsiderInterviewId { get; set; }

        [BsonIgnoreIfNull]
        public bool? HasTest { get; set; }

        [BsonIgnoreIfNull]
        public bool? Archived { get; set; }

        [BsonIgnoreIfNull]
        public bool? Premium { get; set; }

        [BsonIgnoreIfNull]
        public bool? AcceptKids { get; set; }

        [BsonIgnoreIfNull]
        public bool? AllowMessages { get; set; }

        [BsonIgnoreIfNull]
        public bool? AcceptTemporary { get; set; }

        [BsonIgnoreIfNull]
        public bool? AcceptHandicapped { get; set; }

        [BsonIgnoreIfNull]
        public bool? ResponseLetterRequired { get; set; }

        [BsonIgnoreIfNull]
        public bool? AcceptIncompleteResumes { get; set; }

        [BsonRequired]
        public long HeadHunterId { get; set; }

        [BsonRequired]
        public string Name { get; set; }

        [BsonIgnoreIfNull]
        public string? Description { get; set; }

        [BsonIgnoreIfNull]
        public string? AlternateUrl { get; set; }

        [BsonIgnoreIfNull]
        public string? ApplyAlternateUrl { get; set; }

        [BsonIgnoreIfNull]
        public string? BrandedDescription { get; set; }

        [BsonRequired]
        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        public DateTime CreatedAt { get; set; }

        [BsonRequired]
        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        public DateTime PublishedAt { get; set; }

        [BsonRequired]
        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        public DateTime InitialCreatedAt { get; set; }

        [BsonIgnoreIfNull]
        public Salary? Salary { get; set; }

        [BsonIgnoreIfNull]
        public Guid[]? LanguagesIds { get; set; }

        [BsonIgnoreIfNull]
        public Guid[]? KeySkillsIds { get; set; }

        [BsonIgnoreIfNull]
        public Guid[]? WorkingDaysIds { get; set; }

        [BsonIgnoreIfNull]
        public Guid[]? SpecializationsIds { get; set; }

        [BsonIgnoreIfNull]
        public Guid[]? WorkingTimeModesIds { get; set; }

        [BsonIgnoreIfNull]
        public Guid[]? ProfessionalRolesIds { get; set; }

        [BsonIgnoreIfNull]
        public Guid[]? DriverLicenseTypesIds { get; set; }

        [BsonIgnoreIfNull]
        public Guid[]? WorkingTimeIntervalsIds { get; set; }

        public Expression<Func<Vacancy, bool>> IsEqual => (item) => item.HeadHunterId == HeadHunterId;

        public IEnumerable<Expression<Func<Vacancy, object>>> IndexKeys =>
            new List<Expression<Func<Vacancy, object>>>
        {
            item => item.AreaId, item => item.TestId, item => item.AddressId, item => item.ContactId,
            item => item.EmployerId, item => item.ScheduleId, item => item.ExperienceId, item => item.EmploymentId,
            item => item.DepartmentId, item => item.VacancyTypeId, item => item.BillingTypeId, 
            item => item.InsiderInterviewId, item => item.HasTest, item => item.Archived, item => item.Premium,
            item => item.AcceptKids, item => item.AllowMessages, item => item.AcceptTemporary, 
            item => item.AcceptHandicapped, item => item.ResponseLetterRequired, item => item.AcceptIncompleteResumes,
            item => item.HeadHunterId, item => item.Name, item => item.CreatedAt, item => item.PublishedAt,
            item => item.InitialCreatedAt, item => item.Salary.CurrencyId, item => item.Salary.From, 
            item => item.Salary.To, item => item.Salary.Gross, item => item.LanguagesIds, item => item.KeySkillsIds,
            item => item.WorkingDaysIds, item => item.SpecializationsIds, item => item.WorkingTimeModesIds,
            item => item.ProfessionalRolesIds, item => item.WorkingTimeIntervalsIds
        };
    }
}
