namespace HeadHunter.Database.PostgreSQL.Entities
{
    public class VacancySpecialization
    {
        public Guid Id { get; set; }

        public Guid VacancyId { get; set; }

        public Guid SpecializationId { get; set; }

        public virtual Vacancy? Vacancy { get; set; }

        public virtual Specialization? Specialization { get; set; }
    }
}
