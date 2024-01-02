using HeadHunterAggregator.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Entities
{
    [Index(nameof(HeadHunterId), nameof(Title))]
    public class InsiderInterview : EntityBase, IFromHeadHunter
    {
        public string HeadHunterId { get; set; }

        public string Title { get; set; }

        public string Url { get; set; }

        public virtual IReadOnlyCollection<Vacancy>? Vacancies { get; set; }

        public virtual IReadOnlyCollection<EmployerInsiderInterview>? Employers { get; set; }
    }
}
