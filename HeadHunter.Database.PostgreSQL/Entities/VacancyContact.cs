namespace HeadHunter.Database.PostgreSQL.Entities
{
    public class VacancyContact
    {
        public Guid Id { get; set; }

        public Guid VacancyId { get; set; }

        public string? Name { get; set; }

        public string? Email { get; set; }

        public virtual Vacancy? Vacancy { get; set; }

        public virtual ICollection<VacancyContactPhone>? Phones { get; set; }
    }
}
