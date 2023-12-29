using HeadHunterAggregator.Domain.Infrastructure.Databases.Repositories;
using HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Entities;

namespace HeadHunterAggregator.Services.Vacancy.Databases.EntityFramework.Vacancies.Repositories
{
    public interface ILanguageRepository : IRepository<Language>
    {
        Task<Language> FindOneByHeadHunterIdOrAddAsync(Language entity, string headHunterId,
            CancellationToken cancellationToken = default);
    }
}