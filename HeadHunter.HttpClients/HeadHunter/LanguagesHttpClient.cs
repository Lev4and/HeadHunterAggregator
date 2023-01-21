using HeadHunter.HttpClients.Core.ResponseModels;
using HeadHunter.HttpClients.HeadHunter.ResponseModels;

namespace HeadHunter.HttpClients.HeadHunter
{
    public class LanguagesHttpClient : HeadHunterHttpClient, ILanguagesHttpClient
    {
        public LanguagesHttpClient() : base(HeadHunterRoutes.LanguagesPath)
        {

        }

        public async Task<ResponseModel<Language[]>> GetLanguagesAsync()
        {
            return await GetAsync<Language[]>("");
        }
    }
}
