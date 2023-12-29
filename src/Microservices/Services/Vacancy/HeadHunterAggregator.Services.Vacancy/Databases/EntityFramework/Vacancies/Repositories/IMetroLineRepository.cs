using HeadHunterAggregator.Domain.Infrastructure.Databases.Repositories;
using HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Entities;

namespace HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Repositories
{
    public interface IMetroLineRepository : IRepository<MetroLine>
    {
        Task<MetroLine> FindOneByHeadHunterIdOrAddAsync(MetroLine entity, string headHunterId,
            CancellationToken cancellationToken = default);
    }
}