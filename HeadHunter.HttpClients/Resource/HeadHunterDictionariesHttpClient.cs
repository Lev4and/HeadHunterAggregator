using HeadHunter.Model.Common;
using HeadHunter.Models;

namespace HeadHunter.HttpClients.Resource
{
    public class HeadHunterDictionariesHttpClient : ResourceHttpClient
    {
        public HeadHunterDictionariesHttpClient() : base(ResourceRoutes.HeadHunterDictionariesPath)
        {

        }

        public async Task<ResponseModel<Dictionaries>> GetDictionariesAsync()
        {
            return await Get<Dictionaries>("");
        }
    }
}
