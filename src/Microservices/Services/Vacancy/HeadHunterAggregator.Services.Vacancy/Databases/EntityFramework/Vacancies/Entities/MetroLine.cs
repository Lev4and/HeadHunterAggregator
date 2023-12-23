using HeadHunterAggregator.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Entities
{
    public class MetroLine : EntityBase
    {
        public Guid? AreaId { get; set; }

        [Required]
        public string HeadHunterId { get; set; }

        [Required]
        public string Name { get; set; }

        public string? CityId { get; set; }

        public string? HexColor { get; set; }

        public virtual Area? Area { get; set; }

        public virtual IReadOnlyCollection<MetroStation>? Stations { get; set; }
    }
}
