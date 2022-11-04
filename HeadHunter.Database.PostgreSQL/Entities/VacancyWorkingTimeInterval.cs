namespace HeadHunter.Database.PostgreSQL.Entities
{
    public class VacancyWorkingTimeInterval
    {
        public Guid Id { get; set; }

        public Guid VacancyId { get; set; }

        public Guid WorkingTimeIntervalId { get; set; }

        public virtual Vacancy? Vacancy { get; set; }

        public virtual WorkingTimeInterval? WorkingTimeInterval { get; set; }
    }
}
