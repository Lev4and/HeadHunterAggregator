using HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Entities;

namespace HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Repositories
{
    public class EmployerLogoRepository : VacanciesDbRepository<EmployerLogo>, IEmployerLogoRepository
    {
        public EmployerLogoRepository(VacanciesDbContext dbContext) : base(dbContext)
        {
            
        }
    }
}