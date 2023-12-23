using HeadHunterAggregator.Domain.Entities;

namespace HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Entities
{
    public class VacancyLanguage : EntityBase
    {
        public Guid VacancyId { get; set; }

        public Guid LanguageId { get; set; }

        public virtual Vacancy? Vacancy { get; set; }

        public virtual Language? Language { get; set; }
    }
}
