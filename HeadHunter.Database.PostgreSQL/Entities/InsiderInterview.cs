using System.ComponentModel.DataAnnotations;

namespace HeadHunter.Database.PostgreSQL.Entities
{
    public class InsiderInterview
    {
        public Guid Id { get; set; }

        public long HeadHunterId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Url { get; set; }

        public virtual ICollection<Vacancy>? Vacancies { get; set; }

        public virtual ICollection<EmployerInsiderInterview>? Employers { get; set; }
    }
}
