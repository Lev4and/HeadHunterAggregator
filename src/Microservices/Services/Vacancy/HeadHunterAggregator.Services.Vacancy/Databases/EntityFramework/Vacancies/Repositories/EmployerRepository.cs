using HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Entities;

namespace HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Repositories
{
    public class EmployerRepository : VacanciesDbRepository<Employer>, IEmployerRepository
    {
        public EmployerRepository(VacanciesDbContext dbContext) : base(dbContext)
        {
            
        }

        public async Task<Employer> FindOneByHeadHunterIdOrAddAsync(Employer entity, string headHunterId, 
            CancellationToken cancellationToken = default)
        {
            return await FindOneByExpressionOrAddAsync(entity, employer => employer.HeadHunterId == headHunterId,
                cancellationToken);
        }
    }
}