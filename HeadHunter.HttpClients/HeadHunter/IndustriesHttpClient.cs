using HeadHunter.HttpClients.Core.ResponseModels;
using HeadHunter.HttpClients.HeadHunter.ResponseModels;

namespace HeadHunter.HttpClients.HeadHunter
{
    public class IndustriesHttpClient : HeadHunterHttpClient, IIndustriesHttpClient
    {
        public IndustriesHttpClient() : base(HeadHunterRoutes.IndustriesPath)
        {

        }

        public async Task<ResponseModel<Industry[]>> GetIndustriesAsync()
        {
            return await GetAsync<Industry[]>("");
        }
    }
}
