using System.ComponentModel.DataAnnotations;

namespace HeadHunter.Database.PostgreSQL.Entities
{
    public class Currency
    {
        public Guid Id { get; set; }

        [Required]
        public string HeadHunterId { get; set; }

        public virtual ICollection<VacancySalary>? Salaries { get; set; }
    }
}
