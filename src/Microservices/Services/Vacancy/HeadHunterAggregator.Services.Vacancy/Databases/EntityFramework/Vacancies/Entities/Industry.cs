using HeadHunterAggregator.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Entities
{
    [Index(nameof(HeadHunterId), nameof(HeadHunterParentId), nameof(Name))]
    public class Industry : EntityBase
    {
        public Guid? ParentId { get; set; }

        public string HeadHunterId { get; set; }

        public string? HeadHunterParentId { get; set; }

        public string Name { get; set; }

        public virtual Industry? Parent { get; set; }

        public virtual IReadOnlyCollection<Industry>? Children { get; set; }

        public virtual IReadOnlyCollection<EmployerIndustry>? Employers { get; set; }
    }
}
