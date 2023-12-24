using HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Entities;

namespace HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Repositories
{
    public class VacancyWorkingDayRepository : VacanciesDbRepository<VacancyWorkingDay>, IVacancyWorkingDayRepository
    {
        public VacancyWorkingDayRepository(VacanciesDbContext dbContext) : base(dbContext)
        {
            
        }
    }
}