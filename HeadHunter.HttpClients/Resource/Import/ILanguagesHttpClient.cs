using HeadHunter.HttpClients.Core.ResponseModels;
using HeadHunter.HttpClients.HeadHunter.ResponseModels;

namespace HeadHunter.HttpClients.Resource.Import
{
    public interface ILanguagesHttpClient
    {
        Task<ResponseModel<bool>> ImportAsync(Language[] languages);
    }
}
