using HeadHunter.Model.Common;
using HeadHunter.Models;

namespace HeadHunter.HttpClients.HeadHunter
{
    public class IndustriesHttpClient : HeadHunterHttpClient
    {
        public IndustriesHttpClient(): base(HeadHunterRoutes.IndustriesPath)
        {

        }

        public async Task<ResponseModel<Industry[]>> GetIndustriesAsync()
        {
            return await Get<Industry[]>("");
        }
    }
}
