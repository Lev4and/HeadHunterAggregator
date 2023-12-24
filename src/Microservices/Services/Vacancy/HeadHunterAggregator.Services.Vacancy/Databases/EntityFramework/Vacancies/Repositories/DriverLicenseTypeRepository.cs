using HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Entities;

namespace HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Repositories
{
    public class DriverLicenseTypeRepository : VacanciesDbRepository<DriverLicenseType>, IDriverLicenseTypeRepository
    {
        public DriverLicenseTypeRepository(VacanciesDbContext dbContext) : base(dbContext)
        {
            
        }
    }
}