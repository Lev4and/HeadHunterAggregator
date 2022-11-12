using HeadHunter.Database.PostgreSQL.Common.Common;

namespace HeadHunter.Database.PostgreSQL.Common.CRUD.Queries
{
    public interface IFinder<TEntity, TFindModel> where TEntity : class where TFindModel : class
    {
        Task<TEntity?> FindAsync(TFindModel entity);
    }
}
