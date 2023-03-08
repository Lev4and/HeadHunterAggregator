using HeadHunter.HttpClients.Core.ResponseModels;
using HeadHunter.HttpClients.HeadHunter.ResponseModels;

namespace HeadHunter.HttpClients.Resource.Import
{
    public interface IMetroHttpClient
    {
        Task<ResponseModel<bool>> ImportAsync(City[] cities);
    }
}
