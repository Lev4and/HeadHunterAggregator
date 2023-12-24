using HeadHunterAggregator.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Entities
{
    [Index(nameof(Name))]
    public class EmployerType : EntityBase
    {
        public string Name { get; set; }

        public virtual IReadOnlyCollection<Employer>? Employers { get; set; }
    }
}
