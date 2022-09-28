using HeadHunter.Database.MongoDb.Common;
using MongoDB.Driver;

namespace HeadHunter.Database.MongoDb.Collections.IndexKeysDefinitions
{
    public class BillingTypeIndexKeysDefinition : IDefiningIndexKeys<BillingType>
    {
        public List<CreateIndexModel<BillingType>> GetIndexKeys()
        {
            var result = new List<CreateIndexModel<BillingType>>()
            {
                new CreateIndexModel<BillingType>(Builders<BillingType>.IndexKeys.Ascending(area => area.HeadHunterId)),
                new CreateIndexModel<BillingType>(Builders<BillingType>.IndexKeys.Ascending(area => area.Name))
            };

            return result;
        }
    }
}
