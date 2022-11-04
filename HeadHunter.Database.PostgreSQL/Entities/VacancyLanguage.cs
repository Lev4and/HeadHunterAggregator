namespace HeadHunter.Database.PostgreSQL.Entities
{
    public class VacancyLanguage
    {
        public Guid Id { get; set; }

        public Guid VacancyId { get; set; }

        public Guid LanguageId { get; set; }

        public virtual Vacancy? Vacancy { get; set; }

        public virtual Language? Language { get; set; }
    }
}
