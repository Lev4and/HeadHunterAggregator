using HeadHunterAggregator.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Entities
{
    public class EmployerBrandedDescription : EntityBase
    {
        public Guid EmployerId { get; set; }

        [Required]
        public string Description { get; set; }

        public virtual Employer? Employer { get; set; }
    }
}
