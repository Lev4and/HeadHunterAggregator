using HeadHunterAggregator.Domain.Entities;

namespace HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Entities
{
    public class Address : EntityBase, IGeoLocation
    {
        public string? City { get; set; }

        public string? Street { get; set; }

        public string? Building { get; set; }

        public string? Description { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public virtual IReadOnlyCollection<Vacancy>? Vacancies { get; set; }
    }
}
