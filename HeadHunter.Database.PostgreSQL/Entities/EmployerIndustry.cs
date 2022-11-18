namespace HeadHunter.Database.PostgreSQL.Entities
{
    public class EmployerIndustry
    {
        public Guid Id { get; set; }

        public Guid EmployerId { get; set; }

        public Guid IndustryId { get; set; }

        public virtual Employer? Employer { get; set; }

        public virtual Industry? Industry { get; set; }
    }
}
