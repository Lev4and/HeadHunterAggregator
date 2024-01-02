using HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Entities;

namespace HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Repositories
{
    public class EmployerTypeRepository : VacanciesDbRepository<EmployerType>, IEmployerTypeRepository
    {
        public EmployerTypeRepository(VacanciesDbContext dbContext) : base(dbContext)
        {
            
        }

        public async Task<EmployerType> FindOneByHeadHunterIdOrAddAsync(EmployerType entity, string headHunterId, 
            CancellationToken cancellationToken = default)
        {
            return await FindOneByExpressionOrAddAsync(entity, employerType => employerType.HeadHunterId == headHunterId,
                cancellationToken);
        }
    }
}