using HeadHunterAggregator.Domain.Entities;

namespace HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Entities
{
    public class VacancyWorkingDay : EntityBase
    {
        public Guid VacancyId { get; set; }

        public Guid WorkingDayId { get; set; }

        public virtual Vacancy? Vacancy { get; set; }

        public virtual WorkingDay? WorkingDay { get; set; }
    }
}
