using HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Entities;

namespace HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Repositories
{
    public class AddressRepository : VacanciesDbRepository<Address>, IAddressRepository
    {
        public AddressRepository(VacanciesDbContext dbContext) : base(dbContext)
        {
            
        }
    }
}