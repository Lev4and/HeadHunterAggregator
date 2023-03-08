using HeadHunter.HttpClients.Core.ResponseModels;
using HeadHunter.HttpClients.HeadHunter.ResponseModels;

namespace HeadHunter.HttpClients.Resource.Import
{
    public interface IAreasHttpClient
    {
        Task<ResponseModel<bool>> ImportAsync(Area[] areas);
    }
}
