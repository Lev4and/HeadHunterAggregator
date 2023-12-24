using HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Entities;

namespace HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Repositories
{
    public class VacancyWorkingDayRepository : VacanciesDbRepository<VacancyWorkingDay>
    {
        public VacancyWorkingDayRepository(VacanciesDbContext dbContext) : base(dbContext)
        {
            
        }
    }
}