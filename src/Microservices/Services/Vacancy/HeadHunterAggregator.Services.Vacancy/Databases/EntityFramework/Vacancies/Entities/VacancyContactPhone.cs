using HeadHunterAggregator.Domain.Entities;

namespace HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Entities
{
    public class VacancyContactPhone : EntityBase
    {
        public Guid ContactId { get; set; }

        public Guid PhoneId { get; set; }

        public virtual VacancyContact? Contact { get; set; }

        public virtual Phone? Phone { get; set; }
    }
}
