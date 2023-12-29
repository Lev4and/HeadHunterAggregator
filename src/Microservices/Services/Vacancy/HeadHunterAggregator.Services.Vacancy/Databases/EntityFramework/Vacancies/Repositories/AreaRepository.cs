using HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Entities;
using Microsoft.EntityFrameworkCore;

namespace HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Repositories
{
    public class AreaRepository : VacanciesDbRepository<Area>, IAreaRepository
    {
        public AreaRepository(VacanciesDbContext dbContext) : base(dbContext)
        {
            
        }

        public async Task<Area> FindOneByHeadHunterIdAsync(string headHunterId, 
            CancellationToken cancellationToken = default)
        {
            return await _dbContext.Set<Area>().AsNoTracking()
                .SingleAsync(area => area.HeadHunterId == headHunterId, cancellationToken);
        }

        public async Task<Area> FindOneByHeadHunterIdOrAddAsync(Area entity, string headHunterId, 
            CancellationToken cancellationToken = default)
        {
            return await FindOneByExpressionOrAddAsync(entity, area => area.HeadHunterId == headHunterId,
                cancellationToken);
        }
    }
}