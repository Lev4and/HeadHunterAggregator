using HeadHunter.Model.Common;
using HeadHunter.Models;

namespace HeadHunter.HttpClients.HeadHunter
{
    public class LanguagesHttpClient : HeadHunterHttpClient
    {
        public LanguagesHttpClient(): base(HeadHunterRoutes.LanguagesPath)
        {

        }

        public async Task<ResponseModel<Language[]>> GetLanguagesAsync()
        {
            return await Get<Language[]>("");
        }
    }
}
