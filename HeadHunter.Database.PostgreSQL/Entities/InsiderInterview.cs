namespace HeadHunter.Database.PostgreSQL.Entities
{
    public class InsiderInterview
    {
        public Guid Id { get; set; }

        public long HeadHunterId { get; set; }

        public string Title { get; set; }

        public string Url { get; set; }

        public virtual ICollection<EmployerInsiderInterview>? Employers { get; set; }
    }
}
