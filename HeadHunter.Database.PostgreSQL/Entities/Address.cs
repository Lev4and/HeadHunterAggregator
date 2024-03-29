﻿namespace HeadHunter.Database.PostgreSQL.Entities
{
    public class Address
    {
        public Guid Id { get; set; }

        public string? City { get; set; }

        public string? Street { get; set; }

        public string? Building { get; set; }

        public string? Description { get; set; }

        public double? Latitude { get; set; }

        public double? Longitude { get; set; }

        public virtual ICollection<Vacancy>? Vacancies { get; set; }
    }
}
