using HeadHunterAggregator.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Entities
{
    public class WorkingTimeInterval : EntityBase
    {
        [Required]
        public string HeadHunterId { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual IReadOnlyCollection<VacancyWorkingTimeInterval>? Vacancies { get; set; }
    }
}
