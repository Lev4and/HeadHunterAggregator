namespace HeadHunter.Database.PostgreSQL.Entities
{
    public class Area
    {
        public Guid Id { get; set; }

        public Guid? ParentId { get; set; }

        public string HeadHunterId { get; set; }

        public string? HeadHunterParentId { get; set; }

        public string Name { get; set; }

        public virtual Area? Parent { get; set; }

        public virtual ICollection<Area>? Children { get; set; }

        public virtual ICollection<Vacancy>? Vacancies { get; set; }

        public virtual ICollection<Employer>? Employers { get; set; }

        public virtual ICollection<MetroLine>? MetroLines { get; set; }
    }
}
