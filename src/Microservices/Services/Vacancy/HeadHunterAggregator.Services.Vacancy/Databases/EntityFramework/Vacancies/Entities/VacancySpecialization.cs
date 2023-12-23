using HeadHunterAggregator.Domain.Entities;

namespace HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Entities
{
    public class VacancySpecialization : EntityBase
    {
        public Guid VacancyId { get; set; }

        public Guid SpecializationId { get; set; }

        public virtual Vacancy? Vacancy { get; set; }

        public virtual Specialization? Specialization { get; set; }
    }
}
