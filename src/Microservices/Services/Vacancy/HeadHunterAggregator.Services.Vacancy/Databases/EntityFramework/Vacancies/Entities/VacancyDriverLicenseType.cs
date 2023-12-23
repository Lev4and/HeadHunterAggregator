using HeadHunterAggregator.Domain.Entities;

namespace HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Entities
{
    public class VacancyDriverLicenseType : EntityBase
    {
        public Guid VacancyId { get; set; }

        public Guid DriverLicenseTypeId { get; set; }

        public virtual Vacancy? Vacancy { get; set; }

        public virtual DriverLicenseType? DriverLicenseType { get; set; }
    }
}
