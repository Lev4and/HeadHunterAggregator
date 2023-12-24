using HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Entities;

namespace HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Repositories
{
    public class VacancyContactRepository : VacanciesDbRepository<VacancyContact>
    {
        public VacancyContactRepository(VacanciesDbContext dbContext) : base(dbContext)
        {
            
        }
    }
}