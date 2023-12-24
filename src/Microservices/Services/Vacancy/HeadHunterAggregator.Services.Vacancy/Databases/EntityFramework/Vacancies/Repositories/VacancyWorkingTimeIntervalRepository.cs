using HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Entities;

namespace HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Repositories
{
    public class VacancyWorkingTimeIntervalRepository : VacanciesDbRepository<VacancyWorkingTimeInterval>
    {
        public VacancyWorkingTimeIntervalRepository(VacanciesDbContext dbContext) : base(dbContext)
        {
            
        }
    }
}