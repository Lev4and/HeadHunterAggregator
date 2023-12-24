using HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Entities;

namespace HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Repositories
{
    public class LanguageRepository : VacanciesDbRepository<Language>
    {
        public LanguageRepository(VacanciesDbContext dbContext) : base(dbContext)
        {
            
        }
    }
}