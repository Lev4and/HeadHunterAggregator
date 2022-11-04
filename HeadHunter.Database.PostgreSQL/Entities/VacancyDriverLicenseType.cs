namespace HeadHunter.Database.PostgreSQL.Entities
{
    public class VacancyDriverLicenseType
    {
        public Guid Id { get; set; }

        public Guid VacancyId { get; set; }

        public Guid DriverLicenseTypeId { get; set; }

        public virtual Vacancy? Vacancy { get; set; }

        public virtual DriverLicenseType? DriverLicenseType { get; set; }
    }
}
