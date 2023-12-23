using HeadHunterAggregator.Domain.Entities;

namespace HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Entities
{
    public class VacancyProfessionalRole : EntityBase
    {
        public Guid VacancyId { get; set; }

        public Guid ProfessionalRoleId { get; set; }

        public virtual Vacancy? Vacancy { get; set; }

        public virtual ProfessionalRole? ProfessionalRole { get; set; }
    }
}
