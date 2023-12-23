using HeadHunterAggregator.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Entities
{
    public class DriverLicenseType : EntityBase
    {
        [Required]
        public string HeadHunterId { get; set; }

        public virtual IReadOnlyCollection<VacancyDriverLicenseType>? Vacancies { get; set; }
    }
}
