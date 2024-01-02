using HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Entities;

namespace HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Repositories
{
    public class ProfessionalRoleRepository : VacanciesDbRepository<ProfessionalRole>, IProfessionalRoleRepository
    {
        public ProfessionalRoleRepository(VacanciesDbContext dbContext) : base(dbContext)
        {
            
        }

        public async Task<ProfessionalRole> FindOneByHeadHunterIdOrAddAsync(ProfessionalRole entity, string headHunterId, 
            CancellationToken cancellationToken = default)
        {
            return await FindOneByExpressionOrAddAsync(entity, professionalRole => professionalRole.HeadHunterId == headHunterId,
                cancellationToken);
        }
    }
}