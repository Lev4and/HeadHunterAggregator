using HeadHunter.Database.MongoDb.Collections;
using HeadHunter.Database.MongoDb.Features.Employment.Import;
using HeadHunter.Model.Common;

namespace HeadHunter.HttpClients.Resource
{
    public class ImportEmploymentsHttpClient : ResourceHttpClient, IImporter<Employment, Models.Employment>
    {
        public ImportEmploymentsHttpClient() : base(ResourceRoutes.ImportEmploymentsPath)
        {

        }

        public async Task<ResponseModel<Employment>> ImportAsync(Models.Employment model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            return await Post<Employment>("", new Command(model));
        }
    }
}
