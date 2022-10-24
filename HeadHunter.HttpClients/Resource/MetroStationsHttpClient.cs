using HeadHunter.Database.MongoDb.Collections;
using HeadHunter.Model.Common;

namespace HeadHunter.HttpClients.Resource
{
    public class MetroStationsHttpClient : ResourceHttpClient
    {
        public MetroStationsHttpClient() : base(ResourceRoutes.MetroStationsPath)
        {

        }

        public async Task<ResponseModel<List<MetroStation>>> GetAllMetroStationsAsync()
        {
            return await Get<List<MetroStation>>(ResourceRoutes.MetroStationsAllQuery);
        }
    }
}
