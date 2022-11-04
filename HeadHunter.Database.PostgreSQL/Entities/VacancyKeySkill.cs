namespace HeadHunter.Database.PostgreSQL.Entities
{
    public class VacancyKeySkill
    {
        public Guid Id { get; set; }

        public Guid VacancyId { get; set; }

        public Guid KeySkillId { get; set; }

        public virtual Vacancy? Vacancy { get; set; }

        public virtual KeySkill? KeySkill { get; set; }
    }
}
