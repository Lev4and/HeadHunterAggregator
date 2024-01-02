using HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Entities;

namespace HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Repositories
{
    public class DepartmentRepository : VacanciesDbRepository<Department>, IDepartmentRepository
    {
        public DepartmentRepository(VacanciesDbContext dbContext) : base(dbContext)
        {
            
        }

        public async Task<Department> FindOneByHeadHunterIdOrAddAsync(Department entity, string headHunterId, 
            CancellationToken cancellationToken = default)
        {
            return await FindOneByExpressionOrAddAsync(entity, department => department.HeadHunterId == headHunterId,
                cancellationToken);
        }
    }
}