using HeadHunterAggregator.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Entities
{
    public class InsiderInterview : EntityBase
    {
        public long HeadHunterId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Url { get; set; }

        public virtual IReadOnlyCollection<Vacancy>? Vacancies { get; set; }

        public virtual IReadOnlyCollection<EmployerInsiderInterview>? Employers { get; set; }
    }
}
