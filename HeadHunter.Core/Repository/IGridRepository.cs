using HeadHunter.Core.Domain;
using HeadHunter.Core.Specification;

namespace HeadHunter.Core.Repository
{
    public interface IGridRepository
    {
        ValueTask<long> CountAsync<TEntity>(IGridSpecification<TEntity> spec) where TEntity : EntityBase, IAggregateRoot;

        Task<IEnumerable<TEntity>> FindAsync<TEntity>(IGridSpecification<TEntity> spec) where TEntity : EntityBase, 
            IAggregateRoot;
    }
}
