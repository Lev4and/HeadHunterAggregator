namespace HeadHunter.Database.PostgreSQL.Entities
{
    public class VacancyProfessionalRole
    {
        public Guid Id { get; set; }

        public Guid VacancyId { get; set; }

        public Guid ProfessionalRoleId { get; set; }

        public virtual Vacancy? Vacancy { get; set; }

        public virtual ProfessionalRole? ProfessionalRole { get; set; }
    }
}
