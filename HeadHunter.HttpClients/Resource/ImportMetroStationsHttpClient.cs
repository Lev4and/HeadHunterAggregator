using HeadHunter.Database.MongoDb.Collections;
using HeadHunter.Database.MongoDb.Features.MetroStation.Import;
using HeadHunter.Model.Common;

namespace HeadHunter.HttpClients.Resource
{
    public class ImportMetroStationsHttpClient : ResourceHttpClient, IImporter<MetroStation, Models.MetroStation>
    {
        public ImportMetroStationsHttpClient() : base(ResourceRoutes.ImportMetroStationsPath)
        {

        }

        public async Task<ResponseModel<MetroStation>> ImportAsync(Models.MetroStation model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            return await Post<MetroStation>("", new Command(model));
        }
    }
}
