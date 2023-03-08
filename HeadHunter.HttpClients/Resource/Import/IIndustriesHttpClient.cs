using HeadHunter.HttpClients.Core.ResponseModels;
using HeadHunter.HttpClients.HeadHunter.ResponseModels;

namespace HeadHunter.HttpClients.Resource.Import
{
    public interface IIndustriesHttpClient
    {
        Task<ResponseModel<bool>> ImportAsync(Industry[] industries);
    }
}
