using HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Entities;

namespace HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Repositories
{
    public class MetroStationRepository : VacanciesDbRepository<MetroStation>, IMetroStationRepository
    {
        public MetroStationRepository(VacanciesDbContext dbContext) : base(dbContext)
        {
            
        }
    }
}