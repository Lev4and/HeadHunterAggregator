using System.ComponentModel.DataAnnotations;

namespace HeadHunter.Database.PostgreSQL.Entities
{
    public class EmployerDescription
    {
        public Guid Id { get; set; }

        public Guid EmployerId { get; set; }

        [Required]
        public string Description { get; set; }

        public virtual Employer? Employer { get; set; }
    }
}
