using HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Entities;

namespace HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Repositories
{
    public class EmployerInsiderInterviewRepository : VacanciesDbRepository<EmployerInsiderInterview>
    {
        public EmployerInsiderInterviewRepository(VacanciesDbContext dbContext) : base(dbContext)
        {
            
        }
    }
}