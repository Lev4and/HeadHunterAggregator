using HeadHunterAggregator.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Entities
{
    [Index(nameof(Name), nameof(HeadHunterId))]
    public class Specialization : EntityBase
    {
        public Guid? ParentId { get; set; }

        public bool? Laboring { get; set; }

        public string Name { get; set; }

        public string HeadHunterId { get; set; }

        public virtual Specialization? Parent { get; set; }

        public virtual IReadOnlyCollection<Specialization>? Children { get; set; }

        public virtual IReadOnlyCollection<VacancySpecialization>? Vacancies { get; set; }
    }
}
