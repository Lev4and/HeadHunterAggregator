using HeadHunter.Database.MongoDb.Collections;
using HeadHunter.Database.MongoDb.Features.MetroLine.Import;
using HeadHunter.Model.Common;

namespace HeadHunter.HttpClients.Resource
{
    public class ImportMetroLinesHttpClient : ResourceHttpClient, IImporter<MetroLine, Models.MetroLine>
    {
        public ImportMetroLinesHttpClient() : base(ResourceRoutes.ImportMetroLinesPath)
        {

        }

        public async Task<ResponseModel<MetroLine>> ImportAsync(Models.MetroLine model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            return await Post<MetroLine>("", new Command(model));
        }
    }
}
