using HeadHunterAggregator.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Entities
{
    public class Specialization : EntityBase
    {
        public Guid? ParentId { get; set; }

        public bool? Laboring { get; set; }

        [Required]
        public string Name { get; set; }

        public string? ProfareaId { get; set; }

        [Required]
        public string HeadHunterId { get; set; }

        public string? HeadHunterParentId { get; set; }

        public string? ProfareaName { get; set; }

        public virtual Specialization? Parent { get; set; }

        public virtual IReadOnlyCollection<Specialization>? Children { get; set; }

        public virtual IReadOnlyCollection<VacancySpecialization>? Vacancies { get; set; }
    }
}
