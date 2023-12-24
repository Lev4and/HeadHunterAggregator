using HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Entities;

namespace HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Repositories
{
    public class VacancyDescriptionRepository : VacanciesDbRepository<VacancyDescription>
    {
        public VacancyDescriptionRepository(VacanciesDbContext dbContext) : base(dbContext)
        {
            
        }
    }
}