using HeadHunterAggregator.Domain.Infrastructure.Databases.Repositories;
using HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Entities;

namespace HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Repositories
{
    public interface IMetroStationRepository : IRepository<MetroStation>
    {
        Task<MetroStation> FindOneByHeadHunterIdOrAddAsync(MetroStation entity, string headHunterId,
            CancellationToken cancellationToken = default);
    }
}