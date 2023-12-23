using HeadHunterAggregator.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Entities
{
    public class Employer : EntityBase
    {
        public Guid TypeId { get; set; }

        public Guid AreaId { get; set; }

        public bool? Trusted { get; set; }

        public bool? Blacklisted { get; set; }

        public long HeadHunterId { get; set; }

        [Required]
        public string Name { get; set; }

        public string? Url { get; set; }

        public string? SiteUrl { get; set; }

        public string? AlternateUrl { get; set; }

        public string? VacanciesUrl { get; set; }

        public virtual Area? Area { get; set; }

        public virtual EmployerLogo? Logo { get; set; }

        public virtual EmployerType? Type { get; set; }

        public virtual EmployerDescription? Description { get; set; }

        public virtual EmployerBrandedDescription? BrandedDescription { get; set; }

        public virtual IReadOnlyCollection<Vacancy>? Vacancies { get; set; }

        public virtual IReadOnlyCollection<EmployerIndustry>? Industries { get; set; }

        public virtual IReadOnlyCollection<EmployerInsiderInterview>? InsiderInterviews { get; set; }
    }
}
