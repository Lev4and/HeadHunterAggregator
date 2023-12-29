using HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Entities;

namespace HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Repositories
{
    public class MetroLineRepository : VacanciesDbRepository<MetroLine>, IMetroLineRepository
    {
        public MetroLineRepository(VacanciesDbContext dbContext) : base(dbContext)
        {
            
        }

        public async Task<MetroLine> FindOneByHeadHunterIdOrAddAsync(MetroLine entity, string headHunterId, 
            CancellationToken cancellationToken = default)
        {
            return await FindOneByExpressionOrAddAsync(entity, metroLine => metroLine.HeadHunterId == headHunterId,
                cancellationToken);
        }
    }
}