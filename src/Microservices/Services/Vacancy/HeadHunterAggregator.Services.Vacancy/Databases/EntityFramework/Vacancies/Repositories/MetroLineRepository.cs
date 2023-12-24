using HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Entities;

namespace HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Repositories
{
    public class MetroLineRepository : VacanciesDbRepository<MetroLine>
    {
        public MetroLineRepository(VacanciesDbContext dbContext) : base(dbContext)
        {
            
        }
    }
}