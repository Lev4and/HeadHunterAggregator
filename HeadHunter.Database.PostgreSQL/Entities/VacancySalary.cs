namespace HeadHunter.Database.PostgreSQL.Entities
{
    public class VacancySalary
    {
        public Guid Id { get; set; }

        public Guid VacancyId { get; set; }

        public Guid CurrencyId { get; set; }

        public bool? Gross { get; set; }

        public decimal? To { get; set; }

        public decimal? From { get; set; }

        public virtual Vacancy? Vacancy { get; set; }

        public virtual Currency? Currency { get; set; }
    }
}
