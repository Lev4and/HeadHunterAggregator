using HeadHunter.Database.PostgreSQL.Common.Common;

namespace HeadHunter.Database.PostgreSQL.Common.CRUD.Commands
{
    public interface ISaver<TEntity> where TEntity : class
    {
        Task<TEntity> SaveAsync(TEntity entity);
    }
}
