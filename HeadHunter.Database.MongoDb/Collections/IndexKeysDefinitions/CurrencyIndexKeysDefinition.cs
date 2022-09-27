using HeadHunter.Database.MongoDb.Common;
using MongoDB.Driver;

namespace HeadHunter.Database.MongoDb.Collections.IndexKeysDefinitions
{
    public class CurrencyIndexKeysDefinition : IDefiningIndexKeys<Currency>
    {
        public List<CreateIndexModel<Currency>> GetIndexKeys()
        {
            var result = new List<CreateIndexModel<Currency>>()
            {
                new CreateIndexModel<Currency>(Builders<Currency>.IndexKeys.Ascending(area => area.HeadHunterId))
            };

            return result;
        }
    }
}
