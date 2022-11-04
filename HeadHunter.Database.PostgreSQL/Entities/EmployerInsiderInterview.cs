namespace HeadHunter.Database.PostgreSQL.Entities
{
    public class EmployerInsiderInterview
    {
        public Guid Id { get; set; }

        public Guid EmployerId { get; set; }

        public Guid InsiderInterviewId { get; set; }

        public virtual Employer? Employer { get; set; }

        public virtual InsiderInterview? InsiderInterview { get; set; }
    }
}
