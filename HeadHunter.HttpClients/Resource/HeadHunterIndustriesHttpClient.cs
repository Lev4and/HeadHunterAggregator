using HeadHunter.Model.Common;
using HeadHunter.Models;

namespace HeadHunter.HttpClients.Resource
{
    public class HeadHunterIndustriesHttpClient : ResourceHttpClient, IGetAll<Industry>
    {
        public HeadHunterIndustriesHttpClient() : base(ResourceRoutes.HeadHunterIndustriesPath)
        {

        }

        public async Task<ResponseModel<Industry[]>> GetAllAsync()
        {
            return await Get<Industry[]>(ResourceRoutes.HeadHunterIndustriesAllQuery);
        }
    }
}
