using HeadHunterAggregator.Domain.Entities;
using System.Linq.Expressions;

namespace HeadHunterAggregator.Domain.Infrastructure.Databases.Relationships
{
    public interface IRelationship<TEntity, TRelatedEntity>
        where TEntity : EntityBase where TRelatedEntity : EntityBase
    {
        Expression<Func<TRelatedEntity, TEntity?>> ForeignNavigationExpression { get; }

        Expression<Func<TRelatedEntity, object?>> ForeignKeyExpression { get; }
    }
}
