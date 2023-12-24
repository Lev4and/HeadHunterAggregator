using HeadHunterAggregator.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Entities
{
    [Index(nameof(Gross), nameof(To), nameof(From))]
    public class VacancySalary : EntityBase
    {
        public Guid VacancyId { get; set; }

        public Guid CurrencyId { get; set; }

        public bool? Gross { get; set; }

        [Column(TypeName = "decimal(18,6)")]
        public decimal? To { get; set; }

        [Column(TypeName = "decimal(18,6)")]
        public decimal? From { get; set; }

        public virtual Vacancy? Vacancy { get; set; }

        public virtual Currency? Currency { get; set; }
    }
}
