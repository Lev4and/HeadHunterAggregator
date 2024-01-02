using HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Entities;

namespace HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Repositories
{
    public class InsiderInterviewRepository : VacanciesDbRepository<InsiderInterview>, IInsiderInterviewRepository
    {
        public InsiderInterviewRepository(VacanciesDbContext dbContext) : base(dbContext)
        {
            
        }

        public async Task<InsiderInterview> FindOneByHeadHunterIdOrAddAsync(InsiderInterview entity, string headHunterId, 
            CancellationToken cancellationToken = default)
        {
            return await FindOneByExpressionOrAddAsync(entity, insiderInterview => insiderInterview.HeadHunterId == headHunterId,
                cancellationToken);
        }
    }
}