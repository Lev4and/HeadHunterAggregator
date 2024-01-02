using HeadHunterAggregator.Domain.Entities;

namespace HeadHunterAggregator.Domain.Infrastructure.Databases.Mappers
{
    public interface IMapper<TDto, TEntity>
        where TDto : class where TEntity : EntityBase
    {
        TEntity Map(TDto dto);
    }
}
