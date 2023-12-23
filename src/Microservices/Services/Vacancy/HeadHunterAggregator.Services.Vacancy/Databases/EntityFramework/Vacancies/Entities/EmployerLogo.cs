using HeadHunterAggregator.Domain.Entities;

namespace HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Entities
{
    public class EmployerLogo : EntityBase
    {
        public Guid EmployerId { get; set; }

        public string? Small { get; set; }

        public string? Normal { get; set; }

        public string? Original { get; set; }

        public virtual Employer? Employer { get; set; }
    }
}
