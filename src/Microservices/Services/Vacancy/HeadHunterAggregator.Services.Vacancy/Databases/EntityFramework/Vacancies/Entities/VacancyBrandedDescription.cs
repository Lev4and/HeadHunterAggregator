using HeadHunterAggregator.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Entities
{
    public class VacancyBrandedDescription : EntityBase
    {
        public Guid VacancyId { get; set; }

        [Required]
        public string Description { get; set; }

        public virtual Vacancy? Vacancy { get; set; }
    }
}
