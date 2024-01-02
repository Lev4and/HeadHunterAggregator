using HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Entities;

namespace HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Repositories
{
    public class ScheduleRepository : VacanciesDbRepository<Schedule>, IScheduleRepository
    {
        public ScheduleRepository(VacanciesDbContext dbContext) : base(dbContext)
        {
            
        }

        public async Task<Schedule> FindOneByHeadHunterIdOrAddAsync(Schedule entity, string headHunterId, 
            CancellationToken cancellationToken = default)
        {
            return await FindOneByExpressionOrAddAsync(entity, schedule => schedule.HeadHunterId == headHunterId,
                cancellationToken);
        }
    }
}