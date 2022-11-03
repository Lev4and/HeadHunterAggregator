namespace HeadHunter.Database.PostgreSQL.Entities
{
    public class Currency
    {
        public Guid Id { get; set; }

        public string HeadHunterId { get; set; }

        public virtual ICollection<VacancySalary>? Salaries { get; set; }
    }
}
