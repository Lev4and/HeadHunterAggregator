using HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Entities;

namespace HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Repositories
{
    public class VacancySpecializationRepository : VacanciesDbRepository<VacancySpecialization>, 
        IVacancySpecializationRepository
    {
        public VacancySpecializationRepository(VacanciesDbContext dbContext) : base(dbContext)
        {
            
        }
    }
}