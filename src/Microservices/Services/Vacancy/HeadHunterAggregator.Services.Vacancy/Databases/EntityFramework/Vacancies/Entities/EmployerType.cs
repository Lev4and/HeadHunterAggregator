using HeadHunterAggregator.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Entities
{
    public class EmployerType : EntityBase
    {
        [Required]
        public string Name { get; set; }

        public virtual IReadOnlyCollection<Employer>? Employers { get; set; }
    }
}
