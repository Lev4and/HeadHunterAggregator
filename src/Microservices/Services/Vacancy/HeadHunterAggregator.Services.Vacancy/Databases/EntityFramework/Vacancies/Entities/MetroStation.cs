using HeadHunterAggregator.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Entities
{
    [Index(nameof(HeadHunterId), nameof(Name))]
    public class MetroStation : EntityBase
    {
        public Guid MetroLineId { get; set; }

        public int? Order { get; set; }

        public string HeadHunterId { get; set; }

        public string Name { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public virtual MetroLine? Line { get; set; }
    }
}
