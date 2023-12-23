using HeadHunterAggregator.Domain.Entities;

namespace HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Entities
{
    public class VacancyWorkingTimeInterval : EntityBase
    {
        public Guid VacancyId { get; set; }

        public Guid WorkingTimeIntervalId { get; set; }

        public virtual Vacancy? Vacancy { get; set; }

        public virtual WorkingTimeInterval? WorkingTimeInterval { get; set; }
    }
}
