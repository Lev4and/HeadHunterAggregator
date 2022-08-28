using HeadHunter.Model.Common;
using HeadHunter.Models;

namespace HeadHunter.HttpClients.Resource
{
    public class HeadHunterLanguagesHttpClient : ResourceHttpClient
    {
        public HeadHunterLanguagesHttpClient() : base(ResourceRoutes.HeadHunterLanguagesPath)
        {

        }

        public async Task<ResponseModel<Language[]>> GetLanguagesAsync()
        {
            return await Get<Language[]>(ResourceRoutes.HeadHunterLanguagesAllQuery);
        }
    }
}
