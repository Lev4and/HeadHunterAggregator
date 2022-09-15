using HeadHunter.Database.MongoDb.Collections;
using HeadHunter.Database.MongoDb.Features.MetroLine.Import;
using HeadHunter.Model.Common;

namespace HeadHunter.HttpClients.Resource
{
    public class ImportMetroLinesHttpClient : ResourceHttpClient
    {
        public ImportMetroLinesHttpClient() : base(ResourceRoutes.ImportMetroLinesPath)
        {

        }

        public async Task<ResponseModel<MetroLine>> Import(Models.MetroLine metroLine)
        {
            if (metroLine == null)
            {
                throw new ArgumentNullException(nameof(metroLine));
            }

            return await Post<MetroLine>("", new Command(metroLine));
        }
    }
}
