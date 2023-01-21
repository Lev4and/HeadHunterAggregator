using HeadHunter.HttpClients.Core.ResponseModels;
using HeadHunter.HttpClients.HeadHunter.ResponseModels;

namespace HeadHunter.HttpClients.HeadHunter
{
    public class DictionariesHttpClient : HeadHunterHttpClient, IDictionariesHttpClient
    {
        public DictionariesHttpClient() : base(HeadHunterRoutes.DictionariesPath)
        {

        }

        public async Task<ResponseModel<Dictionaries>> GetDictionariesAsync()
        {
            return await GetAsync<Dictionaries>("");
        }
    }
}
