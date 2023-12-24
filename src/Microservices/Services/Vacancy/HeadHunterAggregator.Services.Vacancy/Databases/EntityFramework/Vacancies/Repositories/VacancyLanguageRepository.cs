using HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Entities;

namespace HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Repositories
{
    public class VacancyLanguageRepository : VacanciesDbRepository<VacancyLanguage>, IVacancyLanguageRepository
    {
        public VacancyLanguageRepository(VacanciesDbContext dbContext) : base(dbContext)
        {
            
        }
    }
}