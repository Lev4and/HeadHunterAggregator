using HeadHunterAggregator.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Entities
{
    public class Currency : EntityBase
    {
        [Required]
        public string HeadHunterId { get; set; }

        public virtual IReadOnlyCollection<VacancySalary>? Salaries { get; set; }
    }
}
