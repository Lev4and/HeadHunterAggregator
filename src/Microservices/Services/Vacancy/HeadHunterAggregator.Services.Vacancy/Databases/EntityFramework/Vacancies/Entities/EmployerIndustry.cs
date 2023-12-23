using HeadHunterAggregator.Domain.Entities;

namespace HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Entities
{
    public class EmployerIndustry : EntityBase
    {
        public Guid EmployerId { get; set; }

        public Guid IndustryId { get; set; }

        public virtual Employer? Employer { get; set; }

        public virtual Industry? Industry { get; set; }
    }
}
