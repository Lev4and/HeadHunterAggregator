namespace HeadHunter.Database.PostgreSQL.Entities
{
    public class Industry
    {
        public Guid Id { get; set; }

        public Guid? ParentId { get; set; }

        public string HeadHunterId { get; set; }

        public string? HeadHunterParentId { get; set; }

        public string Name { get; set; }

        public virtual Industry? Parent { get; set; }

        public virtual ICollection<Industry>? Children { get; set; }

        public virtual ICollection<EmployerIndustry>? Employers { get; set; }
    }
}
