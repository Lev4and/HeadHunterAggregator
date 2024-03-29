﻿using System.ComponentModel.DataAnnotations;

namespace HeadHunter.Database.PostgreSQL.Entities
{
    public class VacancyDescription
    {
        public Guid Id { get; set; }

        public Guid VacancyId { get; set; }

        [Required]
        public string Description { get; set; }

        public virtual Vacancy? Vacancy { get; set; }
    }
}
