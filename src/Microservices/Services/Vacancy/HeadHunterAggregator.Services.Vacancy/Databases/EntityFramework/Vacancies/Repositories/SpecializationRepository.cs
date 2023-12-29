using HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Entities;

namespace HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Repositories
{
    public class SpecializationRepository : VacanciesDbRepository<Specialization>, ISpecializationRepository
    {
        public SpecializationRepository(VacanciesDbContext dbContext) : base(dbContext)
        {
            
        }

        public async Task<Specialization> FindOneByHeadHunterIdOrAddAsync(Specialization entity, string headHunterId, 
            CancellationToken cancellationToken = default)
        {
            return await FindOneByExpressionOrAddAsync(entity, specialization => specialization.HeadHunterId == headHunterId,
                cancellationToken);
        }
    }
}