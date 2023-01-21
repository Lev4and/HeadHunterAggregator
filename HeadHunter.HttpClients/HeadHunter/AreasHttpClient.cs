using HeadHunter.HttpClients.Core.ResponseModels;
using HeadHunter.HttpClients.HeadHunter.ResponseModels;

namespace HeadHunter.HttpClients.HeadHunter
{
    public class AreasHttpClient : HeadHunterHttpClient, IAreasHttpClient
    {
        public AreasHttpClient() : base(HeadHunterRoutes.AreasPath)
        {

        }

        public async Task<ResponseModel<Area[]>> GetAreasAsync()
        {
            return await GetAsync<Area[]>("");
        }
    }
}
