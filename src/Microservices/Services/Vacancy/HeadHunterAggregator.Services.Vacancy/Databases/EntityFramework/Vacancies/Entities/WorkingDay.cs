using HeadHunterAggregator.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Entities
{
    [Index(nameof(HeadHunterId), nameof(Name))]
    public class WorkingDay : EntityBase
    {
        public string HeadHunterId { get; set; }

        public string Name { get; set; }

        public virtual IReadOnlyCollection<VacancyWorkingDay>? Vacancies { get; set; }
    }
}
