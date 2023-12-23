using HeadHunterAggregator.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Entities
{
    public class KeySkill : EntityBase
    {
        [Required]
        public string Name { get; set; }

        public virtual IReadOnlyCollection<VacancyKeySkill>? Vacancies { get; set; }
    }
}
