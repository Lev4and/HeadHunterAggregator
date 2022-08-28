using HeadHunter.Model.Common;
using HeadHunter.Models;

namespace HeadHunter.HttpClients.Resource
{
    public class HeadHunterIndustriesHttpClient : ResourceHttpClient
    {
        public HeadHunterIndustriesHttpClient() : base(ResourceRoutes.HeadHunterIndustriesPath)
        {

        }

        public async Task<ResponseModel<Industry[]>> GetIndustriesAsync()
        {
            return await Get<Industry[]>(ResourceRoutes.HeadHunterIndustriesAllQuery);
        }
    }
}
