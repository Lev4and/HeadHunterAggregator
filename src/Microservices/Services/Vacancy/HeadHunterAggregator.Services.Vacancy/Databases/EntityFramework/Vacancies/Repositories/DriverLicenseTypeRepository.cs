using HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Entities;

namespace HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Repositories
{
    public class DriverLicenseTypeRepository : VacanciesDbRepository<DriverLicenseType>
    {
        public DriverLicenseTypeRepository(VacanciesDbContext dbContext) : base(dbContext)
        {
            
        }
    }
}