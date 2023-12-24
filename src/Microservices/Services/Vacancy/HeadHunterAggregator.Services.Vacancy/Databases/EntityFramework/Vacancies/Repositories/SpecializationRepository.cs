using HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Entities;

namespace HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Repositories
{
    public class SpecializationRepository : VacanciesDbRepository<Specialization>
    {
        public SpecializationRepository(VacanciesDbContext dbContext) : base(dbContext)
        {
            
        }
    }
}