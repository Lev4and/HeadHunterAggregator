using HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Entities;

namespace HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Repositories
{
    public class ScheduleRepository : VacanciesDbRepository<Schedule>, IScheduleRepository
    {
        public ScheduleRepository(VacanciesDbContext dbContext) : base(dbContext)
        {
            
        }
    }
}