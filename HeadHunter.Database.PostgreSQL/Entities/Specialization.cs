using System.ComponentModel.DataAnnotations;

namespace HeadHunter.Database.PostgreSQL.Entities
{
    public class Specialization
    {
        public Guid Id { get; set; }

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

        public virtual ICollection<Specialization>? Children { get; set; }

        public virtual ICollection<VacancySpecialization>? Vacancies { get; set; }
    }
}
