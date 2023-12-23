using HeadHunterAggregator.Domain.Entities;

namespace HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Entities
{
    public class VacancyContact : EntityBase
    {
        public Guid VacancyId { get; set; }

        public string? Name { get; set; }

        public string? Email { get; set; }

        public virtual Vacancy? Vacancy { get; set; }

        public virtual IReadOnlyCollection<VacancyContactPhone>? Phones { get; set; }
    }
}
