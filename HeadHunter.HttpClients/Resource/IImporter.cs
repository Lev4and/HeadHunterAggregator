using HeadHunter.Database.MongoDb.Common;
using HeadHunter.Model.Common;

namespace HeadHunter.HttpClients.Resource
{
    public interface IImporter<TCollection, TModel> where TCollection : ICollection where TModel : class
    {
        Task<ResponseModel<TCollection>> ImportAsync(TModel model);
    }
}
