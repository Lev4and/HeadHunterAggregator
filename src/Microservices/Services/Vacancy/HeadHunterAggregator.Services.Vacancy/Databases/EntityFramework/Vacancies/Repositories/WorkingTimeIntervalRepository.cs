using HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Entities;

namespace HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Repositories
{
    public class WorkingTimeIntervalRepository : VacanciesDbRepository<WorkingTimeInterval>
    {
        public WorkingTimeIntervalRepository(VacanciesDbContext dbContext) : base(dbContext)
        {
            
        }
    }
}