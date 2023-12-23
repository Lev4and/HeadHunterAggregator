using HeadHunterAggregator.Domain.Entities;

namespace HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Entities
{
    public class VacancyKeySkill : EntityBase
    {
        public Guid VacancyId { get; set; }

        public Guid KeySkillId { get; set; }

        public virtual Vacancy? Vacancy { get; set; }

        public virtual KeySkill? KeySkill { get; set; }
    }
}
