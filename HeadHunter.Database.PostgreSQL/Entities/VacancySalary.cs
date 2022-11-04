using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace HeadHunter.Database.PostgreSQL.Entities
{
    public class VacancySalary
    {
        public Guid Id { get; set; }

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
