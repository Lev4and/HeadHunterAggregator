using HeadHunterAggregator.Domain.Infrastructure.Databases.Repositories;

namespace HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Repositories
{
    public interface IVacancyRepository : IRepository<Entities.Vacancy>, IFromHeadHunterRepository<Entities.Vacancy>
    {
        
    }
}