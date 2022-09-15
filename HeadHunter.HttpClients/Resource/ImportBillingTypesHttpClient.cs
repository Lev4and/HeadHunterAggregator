using HeadHunter.Database.MongoDb.Collections;
using HeadHunter.Database.MongoDb.Features.BillingType.Import;
using HeadHunter.Model.Common;

namespace HeadHunter.HttpClients.Resource
{
    public class ImportBillingTypesHttpClient : ResourceHttpClient
    {
        public ImportBillingTypesHttpClient() : base(ResourceRoutes.ImportBillingTypesPath)
        {

        }

        public async Task<ResponseModel<BillingType>> Import(Models.BillingType billingType)
        {
            if (billingType == null)
            {
                throw new ArgumentNullException(nameof(billingType));
            }

            return await Post<BillingType>("", new Command(billingType));
        }
    }
}
