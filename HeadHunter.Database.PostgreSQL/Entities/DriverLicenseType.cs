using System.ComponentModel.DataAnnotations;

namespace HeadHunter.Database.PostgreSQL.Entities
{
    public class DriverLicenseType
    {
        public Guid Id { get; set; }

        [Required]
        public string HeadHunterId { get; set; }

        public virtual ICollection<VacancyDriverLicenseType>? Vacancies { get; set; }
    }
}
