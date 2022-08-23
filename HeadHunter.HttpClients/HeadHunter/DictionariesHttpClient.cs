using HeadHunter.Model.Common;
using HeadHunter.Models;

namespace HeadHunter.HttpClients.HeadHunter
{
    public class DictionariesHttpClient : HeadHunterHttpClient
    {
        public DictionariesHttpClient() : base(HeadHunterRoutes.DictionariesPath)
        {

        }

        public async Task<ResponseModel<Dictionaries>> GetDictionariesAsync()
        {
            return await Get<Dictionaries>("");
        }
    }
}
