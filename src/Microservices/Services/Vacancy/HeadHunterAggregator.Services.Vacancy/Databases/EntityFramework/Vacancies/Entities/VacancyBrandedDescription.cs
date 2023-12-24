using HeadHunterAggregator.Domain.Entities;

namespace HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Entities
{
    public class VacancyBrandedDescription : EntityBase
    {
        public Guid VacancyId { get; set; }

        public string Description { get; set; }

        public virtual Vacancy? Vacancy { get; set; }
    }
}
