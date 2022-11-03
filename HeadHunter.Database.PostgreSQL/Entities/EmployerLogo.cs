namespace HeadHunter.Database.PostgreSQL.Entities
{
    public class EmployerLogo
    {
        public Guid Id { get; set; }

        public Guid EmployerId { get; set; }

        public string? Small { get; set; }

        public string? Normal { get; set; }

        public string? Original { get; set; }

        public virtual Employer? Employer { get; set; }
    }
}
