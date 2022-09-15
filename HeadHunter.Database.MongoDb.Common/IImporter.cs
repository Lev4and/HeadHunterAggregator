using MongoDB.Bson;

namespace HeadHunter.Database.MongoDb.Common
{
    public interface IImporter<TColection, TModel> where TColection : ICollection where TModel : class
    {
        Task<TColection> SaveAsync(TModel model);

        Task<TColection> FindAsync(TModel model);

        Task<TColection> ImportAsync(TModel model);
    }
}
