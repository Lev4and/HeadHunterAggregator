using HeadHunterAggregator.Domain.Entities;

namespace HeadHunterAggregator.Domain.Infrastructure.Databases.Mappers
{
    public interface IDbMappers
    {
        IDbMapper<TSource, TEntity> GetDbMapper<TSource, TEntity>()
            where TSource : class 
            where TEntity : EntityBase;

        TEntity Map<TSource, TEntity>(TSource source) 
            where TSource : class 
            where TEntity : EntityBase;
    }
}
