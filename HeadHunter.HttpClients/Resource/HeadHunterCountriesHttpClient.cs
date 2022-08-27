using HeadHunter.Model.Common;
using HeadHunter.Models;

namespace HeadHunter.HttpClients.Resource
{
    public class HeadHunterCountriesHttpClient : ResourceHttpClient
    {
        public HeadHunterCountriesHttpClient() : base(ResourceRoutes.HeadHunterCountriesPath)
        {

        }

        public async Task<ResponseModel<Country[]>> GetAllCountriesAsync()
        {
            return await Get<Country[]>(ResourceRoutes.HeadHunterCountriesAllQuery);
        }
    }
}
