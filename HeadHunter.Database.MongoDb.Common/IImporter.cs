using MongoDB.Bson;

namespace HeadHunter.Database.MongoDb.Common
{
    public interface IImporter<TCollection, TModel> where TCollection : ICollection where TModel : class
    {
        Task<TCollection> SaveAsync(TModel model);

        Task<TCollection> FindAsync(TModel model);

        Task<TCollection> ImportAsync(TModel model);
    }
}
