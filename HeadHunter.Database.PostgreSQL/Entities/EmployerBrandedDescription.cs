namespace HeadHunter.Database.PostgreSQL.Entities
{
    public class EmployerBrandedDescription
    {
        public Guid Id { get; set; }

        public Guid EmployerId { get; set; }

        public string BrandedDescription { get; set; }

        public virtual Employer? Employer { get; set; }
    }
}
