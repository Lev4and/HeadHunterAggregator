using HeadHunter.HttpClients.Core.ResponseModels;
using HeadHunter.HttpClients.HeadHunter.ResponseModels;

namespace HeadHunter.HttpClients.HeadHunter
{
    public class MetroHttpClient : HeadHunterHttpClient, IMetroHttpClient
    {
        public MetroHttpClient() : base(HeadHunterRoutes.MetroPath)
        {

        }

        public async Task<ResponseModel<City[]>> GetMetroStationsAsync()
        {
            return await GetAsync<City[]>("");
        }
    }
}
