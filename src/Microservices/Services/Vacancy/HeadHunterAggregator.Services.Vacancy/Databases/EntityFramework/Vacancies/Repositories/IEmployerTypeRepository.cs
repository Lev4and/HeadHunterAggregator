using HeadHunterAggregator.Domain.Infrastructure.Databases.Repositories;
using HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Entities;

namespace HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Repositories
{
    public interface IEmployerTypeRepository : IRepository<EmployerType>, IFromHeadHunterRepository<EmployerType>
    {

    }
}