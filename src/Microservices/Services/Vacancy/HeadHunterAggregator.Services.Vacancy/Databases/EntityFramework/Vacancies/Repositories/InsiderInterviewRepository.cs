using HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Entities;

namespace HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Repositories
{
    public class InsiderInterviewRepository : VacanciesDbRepository<InsiderInterview>
    {
        public InsiderInterviewRepository(VacanciesDbContext dbContext) : base(dbContext)
        {
            
        }
    }
}