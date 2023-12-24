using HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Entities;

namespace HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Repositories
{
    public class WorkingTimeModeRepository : VacanciesDbRepository<WorkingTimeMode>, IWorkingTimeModeRepository
    {
        public WorkingTimeModeRepository(VacanciesDbContext dbContext) : base(dbContext)
        {
            
        }
    }
}