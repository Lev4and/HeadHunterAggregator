using HeadHunter.Database.MongoDb.Collections;
using HeadHunter.Model.Common;

namespace HeadHunter.HttpClients.Resource
{
    public class IndustriesHttpClient : ResourceHttpClient
    {
        public IndustriesHttpClient() : base(ResourceRoutes.IndustriesPath)
        {

        }

        public async Task<ResponseModel<List<Industry>>> GetAllIndustriesAsync()
        {
            return await Get<List<Industry>>(ResourceRoutes.IndustriesAllQuery);
        }
    }
}
