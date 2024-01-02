using HeadHunterAggregator.Domain.Entities;
using System.Linq.Expressions;

namespace HeadHunterAggregator.Domain.Infrastructure.Databases.Relationships
{
    public interface IOneToOneRelationship<TEntity, TRelatedEntity> : IRelationship<TEntity, TRelatedEntity>
        where TEntity : EntityBase where TRelatedEntity : EntityBase
    {
        Expression<Func<TEntity, TRelatedEntity?>> NavigationExpression { get; }
    }
}
