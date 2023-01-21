using System.Linq.Expressions;

namespace HeadHunter.Core.Specification
{
    public interface ISpecification<TEntity> : IRootSpecification
    {
        int Take { get; }

        int Skip { get; }

        bool IsPagingEnabled { get; }

        Expression<Func<TEntity, bool>> Criteria { get; }

        Expression<Func<TEntity, object>> OrderBy { get; }

        Expression<Func<TEntity, object>> OrderByDescending { get; }

        Expression<Func<TEntity, object>> GroupBy { get; }

        List<string> IncludeStrings { get; }

        List<Expression<Func<TEntity, object>>> Includes { get; }

        bool IsSatisfiedBy(TEntity obj);
    }
}
