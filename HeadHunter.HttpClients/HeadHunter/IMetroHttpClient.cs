using HeadHunter.HttpClients.Core.ResponseModels;
using HeadHunter.HttpClients.HeadHunter.ResponseModels;

namespace HeadHunter.HttpClients.HeadHunter
{
    public interface IMetroHttpClient
    {
        Task<ResponseModel<City[]>> GetMetroStationsAsync();
    }
}
