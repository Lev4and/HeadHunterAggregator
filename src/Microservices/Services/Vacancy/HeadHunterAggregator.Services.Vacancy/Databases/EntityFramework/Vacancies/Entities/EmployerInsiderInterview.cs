using HeadHunterAggregator.Domain.Entities;

namespace HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Entities
{
    public class EmployerInsiderInterview : EntityBase
    {
        public Guid EmployerId { get; set; }

        public Guid InsiderInterviewId { get; set; }

        public virtual Employer? Employer { get; set; }

        public virtual InsiderInterview? InsiderInterview { get; set; }
    }
}
