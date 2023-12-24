using HeadHunterAggregator.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Entities
{
    [Index(nameof(HasTest), nameof(Premium), nameof(Archived), nameof(AcceptKids), nameof(AllowMessages), nameof(AcceptTemporary),
        nameof(AcceptHandicapped), nameof(ResponseLetterRequired), nameof(AcceptIncompleteResumes), nameof(HeadHunterId),
            nameof(Name), nameof(CreatedAt), nameof(PublishedAt), nameof(InitialCreatedAt))]
    public class Vacancy : EntityBase
    {
        public Guid AreaId { get; set; }

        public Guid? TypeId { get; set; }

        public Guid? AddressId { get; set; }

        public Guid EmployerId { get; set; }

        public Guid ScheduleId { get; set; }

        public Guid ExperienceId { get; set; }

        public Guid EmploymentId { get; set; }

        public Guid? DepartmentId { get; set; }

        public Guid BillingTypeId { get; set; }

        public Guid? InsiderInterviewId { get; set; }

        public bool HasTest { get; set; }

        public bool Premium { get; set; }

        public bool Archived { get; set; }

        public bool AcceptKids { get; set; }

        public bool AllowMessages { get; set; }

        public bool? AcceptTemporary { get; set; }

        public bool AcceptHandicapped { get; set; }

        public bool ResponseLetterRequired { get; set; }

        public bool AcceptIncompleteResumes { get; set; }

        public long HeadHunterId { get; set; }

        public string Name { get; set; }

        public string? Code { get; set; }

        public string AlternateUrl { get; set; }

        public string ApplyAlternateUrl { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime PublishedAt { get; set; }

        public DateTime InitialCreatedAt { get; set; }

        public virtual Area? Area { get; set; }

        public virtual Address? Address { get; set; }

        public virtual VacancyType? Type { get; set; }

        public virtual Employer? Employer { get; set; }

        public virtual Schedule? Schedule { get; set; }

        public virtual VacancySalary? Salary { get; set; }

        public virtual Experience? Experience { get; set; }

        public virtual Employment? Employment { get; set; }

        public virtual Department? Department { get; set; }

        public virtual VacancyContact? Contact { get; set; }

        public virtual BillingType? BillingType { get; set; }

        public virtual VacancyDescription? Description { get; set; }

        public virtual InsiderInterview? InsiderInterview { get; set; }

        public virtual VacancyBrandedDescription? BrandedDescription { get; set; }

        public virtual IReadOnlyCollection<VacancyLanguage>? Languages { get; set; }

        public virtual IReadOnlyCollection<VacancyKeySkill>? KeySkills { get; set; }

        public virtual IReadOnlyCollection<VacancyWorkingDay>? WorkingDays { get; set; }

        public virtual IReadOnlyCollection<VacancySpecialization>? Specializations { get; set; }

        public virtual IReadOnlyCollection<VacancyWorkingTimeMode>? WorkingTimeModes { get; set; }

        public virtual IReadOnlyCollection<VacancyProfessionalRole>? ProfessionalRoles { get; set; }

        public virtual IReadOnlyCollection<VacancyDriverLicenseType>? DriverLicenseTypes { get; set; }

        public virtual IReadOnlyCollection<VacancyWorkingTimeInterval>? WorkingTimeIntervals { get; set; }
    }
}
