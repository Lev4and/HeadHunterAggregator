using HeadHunterAggregator.Domain.Entities;

namespace HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Entities
{
    public class VacancyWorkingTimeMode : EntityBase
    {
        public Guid VacancyId { get; set; }

        public Guid WorkingTimeModeId { get; set; }

        public virtual Vacancy? Vacancy { get; set; }

        public virtual WorkingTimeMode? WorkingTimeMode { get; set; }
    }
}
