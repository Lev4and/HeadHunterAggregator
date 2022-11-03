namespace HeadHunter.Database.PostgreSQL.Entities
{
    public class EmployerType
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Employer>? Employers { get; set; }
    }
}
