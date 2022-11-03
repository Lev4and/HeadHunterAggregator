namespace HeadHunter.Database.PostgreSQL.Entities
{
    public class EmployerDescription
    {
        public Guid Id { get; set; }

        public Guid EmployerId { get; set; }

        public string Description { get; set; }

        public virtual Employer? Employer { get; set; }
    }
}
