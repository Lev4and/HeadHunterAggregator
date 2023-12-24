using HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Entities;

namespace HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Repositories
{
    public class VacancyProfessionalRoleRepository : VacanciesDbRepository<VacancyProfessionalRole>, 
        IVacancyProfessionalRoleRepository
    {
        public VacancyProfessionalRoleRepository(VacanciesDbContext dbContext) : base(dbContext)
        {
            
        }
    }
}