using System.Linq.Expressions;

namespace HeadHunter.Core.Specification
{
    public interface IGridSpecification<TEntity> : IRootSpecification
    {
        bool IsPagingEnabled { get; set; }

        int Take { get; }

        int Skip { get; }

        Expression<Func<TEntity, object>> GroupBy { get; }

        Expression<Func<TEntity, object>> OrderBy { get; }

        Expression<Func<TEntity, object>> OrderByDescending { get; }

        List<string> IncludeStrings { get; }

        List<Expression<Func<TEntity, bool>>> Criterias { get; }

        List<Expression<Func<TEntity, object>>> Includes { get; }
    }
}
