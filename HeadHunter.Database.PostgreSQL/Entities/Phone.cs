namespace HeadHunter.Database.PostgreSQL.Entities
{
    public class Phone
    {
        public Guid Id { get; set; }

        public string? City { get; set; }

        public string? Number { get; set; }

        public string? Comment { get; set; }

        public string? Country { get; set; }

        public virtual ICollection<VacancyContactPhone>? VacancyContacts { get; set; }
    }
}
