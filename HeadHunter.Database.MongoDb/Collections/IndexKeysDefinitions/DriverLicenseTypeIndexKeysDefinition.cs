using HeadHunter.Database.MongoDb.Common;
using MongoDB.Driver;

namespace HeadHunter.Database.MongoDb.Collections.IndexKeysDefinitions
{
    public class DriverLicenseTypeIndexKeysDefinition : IDefiningIndexKeys<DriverLicenseType>
    {
        public List<CreateIndexModel<DriverLicenseType>> GetIndexKeys()
        {
            var result = new List<CreateIndexModel<DriverLicenseType>>()
            {
                new CreateIndexModel<DriverLicenseType>(Builders<DriverLicenseType>.IndexKeys.Ascending(area => area.HeadHunterId))
            };

            return result;
        }
    }
}
