using HeadHunter.Database.MongoDb.Collections;
using HeadHunter.Database.MongoDb.Features.BillingType.Import;
using HeadHunter.Model.Common;

namespace HeadHunter.HttpClients.Resource
{
    public class ImportBillingTypesHttpClient : ResourceHttpClient, IImporter<BillingType, Models.BillingType>
    {
        public ImportBillingTypesHttpClient() : base(ResourceRoutes.ImportBillingTypesPath)
        {

        }

        public async Task<ResponseModel<BillingType>> ImportAsync(Models.BillingType model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            return await Post<BillingType>("", new Command(model));
        }
    }
}
