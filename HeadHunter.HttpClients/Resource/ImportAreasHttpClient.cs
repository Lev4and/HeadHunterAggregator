using HeadHunter.Database.MongoDb.Collections;
using HeadHunter.Database.MongoDb.Features.Area.Import;
using HeadHunter.Model.Common;

namespace HeadHunter.HttpClients.Resource
{
    public class ImportAreasHttpClient : ResourceHttpClient, IImporter<Area, Models.Area>
    {
        public ImportAreasHttpClient() : base(ResourceRoutes.ImportAreasPath)
        {

        }

        public async Task<ResponseModel<Area>> ImportAsync(Models.Area model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            return await Post<Area>("", new Command(model));
        }
    }
}
