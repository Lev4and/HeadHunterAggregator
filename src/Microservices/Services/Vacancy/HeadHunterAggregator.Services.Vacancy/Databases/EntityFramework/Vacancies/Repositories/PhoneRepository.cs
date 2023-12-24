using HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Entities;

namespace HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Repositories
{
    public class PhoneRepository : VacanciesDbRepository<Phone>, IPhoneRepository
    {
        public PhoneRepository(VacanciesDbContext dbContext) : base(dbContext)
        {
            
        }
    }
}