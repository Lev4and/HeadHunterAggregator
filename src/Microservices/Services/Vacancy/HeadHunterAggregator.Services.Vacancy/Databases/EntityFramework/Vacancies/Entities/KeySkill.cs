using HeadHunterAggregator.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Entities
{
    [Index(nameof(Name))]
    public class KeySkill : EntityBase
    {
        public string Name { get; set; }

        public virtual IReadOnlyCollection<VacancyKeySkill>? Vacancies { get; set; }
    }
}
