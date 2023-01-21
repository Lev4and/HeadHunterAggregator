using HeadHunter.Core.Domain;
using HeadHunter.Core.Specification;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HeadHunter.Core.Repository
{
    public interface IRepository
    {
        Task<TEntity?> FindByIdAsync<TEntity>(Guid id) where TEntity : EntityBase, IAggregateRoot, 
            IEqualSpecification<TEntity>;

        Task<TEntity?> FindByExpressionAsync<TEntity>(IEqualSpecification<TEntity> specification) where TEntity : 
            EntityBase, IAggregateRoot, IEqualSpecification<TEntity>;

        Task<TEntity?> FindOneAsync<TEntity>(ISpecification<TEntity> specification) where TEntity : EntityBase, 
            IAggregateRoot, IEqualSpecification<TEntity>;

        Task<IEnumerable<TEntity>> FindAsync<TEntity>(ISpecification<TEntity> specification) where TEntity : EntityBase,
            IAggregateRoot, IEqualSpecification<TEntity>;

        Task<TEntity> AddAsync<TEntity>(TEntity entity) where TEntity : EntityBase, IAggregateRoot, 
            IEqualSpecification<TEntity>;

        Task<TEntity> TryImportAsync<TEntity>(TEntity entity) where TEntity : EntityBase, IAggregateRoot, 
            IEqualSpecification<TEntity>;

        Task RemoveAsync<TEntity>(TEntity entity) where TEntity : EntityBase, IAggregateRoot, 
            IEqualSpecification<TEntity>;
    }
}
