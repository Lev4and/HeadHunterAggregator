using HeadHunter.Database.MongoDb.Collections;
using HeadHunter.Model.Common;

namespace HeadHunter.HttpClients.Resource
{
    public class BillingTypesHttpClient : ResourceHttpClient
    {
        public BillingTypesHttpClient() : base(ResourceRoutes.BillingTypesPath)
        {

        }

        public async Task<ResponseModel<List<BillingType>>> GetAllBillingTypesAsync()
        {
            return await Get<List<BillingType>>(ResourceRoutes.BillingTypesAllQuery);
        }
    }
}
