using HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Entities;

namespace HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Repositories
{
    public class IndustryRepository : VacanciesDbRepository<Industry>, IIndustryRepository
    {
        public IndustryRepository(VacanciesDbContext dbContext) : base(dbContext)
        {
            
        }

        public async Task<Industry> FindOneByHeadHunterIdOrAddAsync(Industry entity, string headHunterId, 
            CancellationToken cancellationToken = default)
        {
            return await FindOneByExpressionOrAddAsync(entity, industry => industry.HeadHunterId == headHunterId,
                cancellationToken);
        }
    }
}