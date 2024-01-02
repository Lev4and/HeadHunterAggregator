using HeadHunterAggregator.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Entities
{
    [Index(nameof(HeadHunterId), nameof(Name))]
    public class MetroLine : EntityBase, IFromHeadHunter
    {
        public Guid AreaId { get; set; }

        public string HeadHunterId { get; set; }

        public string Name { get; set; }

        public string? HexColor { get; set; }

        public virtual Area? Area { get; set; }

        public virtual IReadOnlyCollection<MetroStation>? Stations { get; set; }
    }
}
