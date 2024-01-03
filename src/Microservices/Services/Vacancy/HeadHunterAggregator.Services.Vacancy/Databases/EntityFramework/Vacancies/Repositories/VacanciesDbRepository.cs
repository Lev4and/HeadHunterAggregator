using HeadHunterAggregator.Domain.Entities;
using HeadHunterAggregator.Infrastructure.Databases.EntityFramework.Repositories;

namespace HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Repositories
{
    public class VacanciesDbRepository : EntityFrameworkRepository<VacanciesDbContext>
    {
        public VacanciesDbRepository(VacanciesDbContext dbContext) : base(dbContext)
        {

        }
    }

    public class VacanciesDbRepository<TEntity> : EntityFrameworkRepository<VacanciesDbContext, TEntity>
        where TEntity : EntityBase
    {
        public VacanciesDbRepository(VacanciesDbContext dbContext) : base(dbContext)
        {
            
        }
    }
}
