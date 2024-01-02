using HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Entities;

namespace HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Repositories
{
    public class WorkingTimeIntervalRepository : VacanciesDbRepository<WorkingTimeInterval>, IWorkingTimeIntervalRepository
    {
        public WorkingTimeIntervalRepository(VacanciesDbContext dbContext) : base(dbContext)
        {
            
        }

        public async Task<WorkingTimeInterval> FindOneByHeadHunterIdOrAddAsync(WorkingTimeInterval entity, string headHunterId, 
            CancellationToken cancellationToken = default)
        {
            return await FindOneByExpressionOrAddAsync(entity, workingTimeInterval => workingTimeInterval.HeadHunterId == headHunterId,
                cancellationToken);
        }
    }
}