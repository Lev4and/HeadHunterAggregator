using HeadHunter.Database.MongoDb.Collections;
using HeadHunter.Database.MongoDb.Features.Area.Import;
using HeadHunter.Model.Common;

namespace HeadHunter.HttpClients.Resource
{
    public class ImportAreasHttpClient : ResourceHttpClient
    {
        public ImportAreasHttpClient() : base(ResourceRoutes.ImportAreasPath)
        {

        }

        public async Task<ResponseModel<Area>> Import(Models.Area area)
        {
            if (area == null)
            {
                throw new ArgumentNullException(nameof(area));
            }

            return await Post<Area>("", new Command(area));
        }
    }
}
