namespace HeadHunter.Database.PostgreSQL.Entities
{
    public class VacancyWorkingTimeMode
    {
        public Guid Id { get; set; }

        public Guid VacancyId { get; set; }

        public Guid WorkingTimeModeId { get; set; }

        public virtual Vacancy? Vacancy { get; set; }

        public virtual WorkingTimeMode? WorkingTimeMode { get; set; }
    }
}
