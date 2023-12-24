using HeadHunterAggregator.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Entities
{
    [Index(nameof(HeadHunterId), nameof(HeadHunterParentId), nameof(Name))]
    public class Area : EntityBase
    {
        public Guid? ParentId { get; set; }

        public string HeadHunterId { get; set; }

        public string? HeadHunterParentId { get; set; }

        public string Name { get; set; }

        public virtual Area? Parent { get; set; }

        public virtual IReadOnlyCollection<Area>? Children { get; set; }

        public virtual IReadOnlyCollection<Vacancy>? Vacancies { get; set; }

        public virtual IReadOnlyCollection<Employer>? Employers { get; set; }

        public virtual IReadOnlyCollection<MetroLine>? MetroLines { get; set; }
    }
}
