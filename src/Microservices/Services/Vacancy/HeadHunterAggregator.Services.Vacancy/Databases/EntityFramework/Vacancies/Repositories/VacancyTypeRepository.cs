using HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Entities;

namespace HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Repositories
{
    public class VacancyTypeRepository : VacanciesDbRepository<VacancyType>, IVacancyTypeRepository
    {
        public VacancyTypeRepository(VacanciesDbContext dbContext) : base(dbContext)
        {
            
        }

        public async Task<VacancyType> FindOneByHeadHunterIdOrAddAsync(VacancyType entity, string headHunterId, 
            CancellationToken cancellationToken = default)
        {
            return await FindOneByExpressionOrAddAsync(entity, vacancyType => vacancyType.HeadHunterId == headHunterId,
                cancellationToken);
        }
    }
}