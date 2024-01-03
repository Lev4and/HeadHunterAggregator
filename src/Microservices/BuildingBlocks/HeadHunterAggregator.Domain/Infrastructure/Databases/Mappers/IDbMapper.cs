using HeadHunterAggregator.Domain.Entities;

namespace HeadHunterAggregator.Domain.Infrastructure.Databases.Mappers
{
    public interface IDbMapper<TSource, TEntity>
        where TSource : class where TEntity : EntityBase
    {
        TEntity Map(TSource dto);
    }
}
