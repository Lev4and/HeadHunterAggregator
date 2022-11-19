using HeadHunter.Database.MongoDb.Common;
using MongoDB.Driver;
using System.Linq.Expressions;

namespace HeadHunter.Database.MongoDb.Collections.IndexKeysDefinitions
{
    public class DriverLicenseTypeIndexKeysDefinition : IDefiningIndexKeys<DriverLicenseType>
    {
        public IEnumerable<CreateIndexModel<DriverLicenseType>> GetIndexKeys()
        {
            var fields = new List<Expression<Func<DriverLicenseType, object>>>()
            {
                item => item.HeadHunterId
            };

            return CreatorCreateIndexModel.Create(fields.ToArray());
        }
    }
}
