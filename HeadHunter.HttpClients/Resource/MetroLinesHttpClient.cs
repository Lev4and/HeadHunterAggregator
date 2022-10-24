using HeadHunter.Database.MongoDb.Collections;
using HeadHunter.Model.Common;

namespace HeadHunter.HttpClients.Resource
{
    public class MetroLinesHttpClient : ResourceHttpClient
    {
        public MetroLinesHttpClient() : base(ResourceRoutes.MetroLinesPath)
        {

        }

        public async Task<ResponseModel<List<MetroLine>>> GetAllMetroLinesAsync()
        {
            return await Get<List<MetroLine>>(ResourceRoutes.MetroLinesAllQuery);
        }
    }
}
