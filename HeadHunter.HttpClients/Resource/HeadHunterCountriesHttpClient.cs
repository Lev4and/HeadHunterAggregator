using HeadHunter.Model.Common;
using HeadHunter.Models;

namespace HeadHunter.HttpClients.Resource
{
    public class HeadHunterCountriesHttpClient : ResourceHttpClient, IGetAll<Country>
    {
        public HeadHunterCountriesHttpClient() : base(ResourceRoutes.HeadHunterCountriesPath)
        {

        }

        public async Task<ResponseModel<Country[]>> GetAllAsync()
        {
            return await Get<Country[]>(ResourceRoutes.HeadHunterCountriesAllQuery);
        }
    }
}
