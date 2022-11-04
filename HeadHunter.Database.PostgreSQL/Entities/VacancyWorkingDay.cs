namespace HeadHunter.Database.PostgreSQL.Entities
{
    public class VacancyWorkingDay
    {
        public Guid Id { get; set; }

        public Guid VacancyId { get; set; }

        public Guid WorkingDayId { get; set; }

        public virtual Vacancy? Vacancy { get; set; }

        public virtual WorkingDay? WorkingDay { get; set; }
    }
}
