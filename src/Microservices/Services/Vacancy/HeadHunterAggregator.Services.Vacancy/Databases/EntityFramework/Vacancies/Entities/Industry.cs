using HeadHunterAggregator.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Entities
{
    public class Industry : EntityBase
    {
        public Guid? ParentId { get; set; }

        [Required]
        public string HeadHunterId { get; set; }

        public string? HeadHunterParentId { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual Industry? Parent { get; set; }

        public virtual IReadOnlyCollection<Industry>? Children { get; set; }

        public virtual IReadOnlyCollection<EmployerIndustry>? Employers { get; set; }
    }
}
