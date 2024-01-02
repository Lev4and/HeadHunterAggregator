using HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Entities;

namespace HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Repositories
{
    public class CurrencyRepository : VacanciesDbRepository<Currency>, ICurrencyRepository
    {
        public CurrencyRepository(VacanciesDbContext dbContext) : base(dbContext)
        {
            
        }

        public async Task<Currency> FindOneByHeadHunterIdOrAddAsync(Currency entity, string headHunterId, 
            CancellationToken cancellationToken = default)
        {
            return await FindOneByExpressionOrAddAsync(entity, currency => currency.HeadHunterId == headHunterId,
                cancellationToken);
        }
    }
}