using HeadHunterAggregator.Domain.Entities;

namespace HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Entities
{
    public class Phone : EntityBase
    {
        public string? City { get; set; }

        public string? Number { get; set; }

        public string? Comment { get; set; }

        public string? Country { get; set; }

        public virtual IReadOnlyCollection<VacancyContactPhone>? VacancyContacts { get; set; }
    }
}
