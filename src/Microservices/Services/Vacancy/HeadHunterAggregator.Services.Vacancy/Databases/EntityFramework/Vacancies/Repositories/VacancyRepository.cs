
namespace HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Repositories
{
    public class VacancyRepository : VacanciesDbRepository<Entities.Vacancy>, IVacancyRepository
    {
        public VacancyRepository(VacanciesDbContext dbContext) : base(dbContext)
        {
            
        }

        public async Task<Entities.Vacancy> FindOneByHeadHunterIdOrAddAsync(Entities.Vacancy entity, string headHunterId, 
            CancellationToken cancellationToken = default)
        {
            return await FindOneByExpressionOrAddAsync(entity, vacancy => vacancy.HeadHunterId == headHunterId,
                cancellationToken);
        }
    }
}