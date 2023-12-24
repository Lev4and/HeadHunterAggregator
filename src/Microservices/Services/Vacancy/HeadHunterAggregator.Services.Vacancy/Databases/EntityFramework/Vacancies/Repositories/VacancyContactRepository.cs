using HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Entities;

namespace HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Repositories
{
    public class VacancyContactRepository : VacanciesDbRepository<VacancyContact>, IVacancyContactRepository
    {
        public VacancyContactRepository(VacanciesDbContext dbContext) : base(dbContext)
        {
            
        }
    }
}