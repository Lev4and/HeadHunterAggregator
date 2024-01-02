using HeadHunterAggregator.Domain.Infrastructure.Databases.Repositories;
using HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Entities;

namespace HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Repositories
{
    public interface IAreaRepository : IRepository<Area>, IFromHeadHunterRepository<Area>
    {
        Task<Area> FindOneByHeadHunterIdAsync(string headHunterId,
            CancellationToken cancellationToken = default);
    }
}