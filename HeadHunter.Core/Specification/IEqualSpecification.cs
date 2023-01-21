using System.Linq.Expressions;

namespace HeadHunter.Core.Specification
{
    public interface IEqualSpecification<TEntity> : IRootSpecification
    {
        Expression<Func<TEntity, bool>> IsEqual { get; }
    }
}
