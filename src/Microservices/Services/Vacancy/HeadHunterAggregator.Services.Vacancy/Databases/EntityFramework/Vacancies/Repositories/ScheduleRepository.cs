using HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Entities;

namespace HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Repositories
{
    public class ScheduleRepository : VacanciesDbRepository<Schedule>
    {
        public ScheduleRepository(VacanciesDbContext dbContext) : base(dbContext)
        {
            
        }
    }
}