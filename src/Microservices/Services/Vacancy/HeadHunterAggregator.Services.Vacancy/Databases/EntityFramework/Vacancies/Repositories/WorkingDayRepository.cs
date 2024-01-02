using HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Entities;

namespace HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Repositories
{
    public class WorkingDayRepository : VacanciesDbRepository<WorkingDay>, IWorkingDayRepository
    {
        public WorkingDayRepository(VacanciesDbContext dbContext) : base(dbContext)
        {
            
        }

        public async Task<WorkingDay> FindOneByHeadHunterIdOrAddAsync(WorkingDay entity, string headHunterId, 
            CancellationToken cancellationToken = default)
        {
            return await FindOneByExpressionOrAddAsync(entity, workingDay => workingDay.HeadHunterId == headHunterId,
                cancellationToken);
        }
    }
}