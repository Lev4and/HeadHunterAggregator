using HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Entities;

namespace HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Repositories
{
    public class VacancyWorkingTimeModeRepository : VacanciesDbRepository<VacancyWorkingTimeMode>, 
        IVacancyWorkingTimeModeRepository
    {
        public VacancyWorkingTimeModeRepository(VacanciesDbContext dbContext) : base(dbContext)
        {
            
        }
    }
}