using System.ComponentModel.DataAnnotations;

namespace HeadHunter.Database.PostgreSQL.Entities
{
    public class Language
    {
        public Guid Id { get; set; }

        [Required]
        public string HeadHunterId { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<VacancyLanguage>? Vacancies { get; set; }
    }
}
