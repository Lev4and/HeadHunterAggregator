using HeadHunterAggregator.Domain.Infrastructure.Databases.Repositories;
using HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Entities;

namespace HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Repositories
{
    public interface IIndustryRepository : IRepository<Industry>
    {
        Task<Industry> FindOneByHeadHunterIdOrAddAsync(Industry entity, string headHunterId,
            CancellationToken cancellationToken = default);
    }
}