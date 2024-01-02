using HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Entities;

namespace HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Repositories
{
    public class BillingTypeRepository : VacanciesDbRepository<BillingType>, IBillingTypeRepository
    {
        public BillingTypeRepository(VacanciesDbContext dbContext) : base(dbContext)
        {
            
        }

        public async Task<BillingType> FindOneByHeadHunterIdOrAddAsync(BillingType entity, string headHunterId, 
            CancellationToken cancellationToken = default)
        {
            return await FindOneByExpressionOrAddAsync(entity, billingType => billingType.HeadHunterId == headHunterId,
                cancellationToken);
        }
    }
}