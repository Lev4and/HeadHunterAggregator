using HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Entities;

namespace HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Repositories
{
    public class VacancyDriverLicenseTypeRepository : VacanciesDbRepository<VacancyDriverLicenseType>, 
        IVacancyDriverLicenseTypeRepository
    {
        public VacancyDriverLicenseTypeRepository(VacanciesDbContext dbContext) : base(dbContext)
        {
            
        }
    }
}