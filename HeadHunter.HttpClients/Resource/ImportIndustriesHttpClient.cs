using HeadHunter.Database.MongoDb.Collections;
using HeadHunter.Database.MongoDb.Features.Industry.Import;
using HeadHunter.Model.Common;

namespace HeadHunter.HttpClients.Resource
{
    public class ImportIndustriesHttpClient : ResourceHttpClient, IImporter<Industry, Models.Industry>
    {
        public ImportIndustriesHttpClient() : base(ResourceRoutes.ImportIndustriesPath)
        {

        }

        public async Task<ResponseModel<Industry>> ImportAsync(Models.Industry model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            return await Post<Industry>("", new Command(model));
        }
    }
}
