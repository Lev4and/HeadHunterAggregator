using HeadHunter.HttpClients.Core.ResponseModels;
using HeadHunter.HttpClients.HeadHunter.ResponseModels;

namespace HeadHunter.HttpClients.Resource.Import
{
    public interface IDictionariesHttpClient
    {
        Task<ResponseModel<bool>> ImportAsync(Dictionaries dictionaries);
    }
}
