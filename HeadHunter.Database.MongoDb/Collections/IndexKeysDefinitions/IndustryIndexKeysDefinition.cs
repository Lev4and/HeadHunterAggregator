using HeadHunter.Database.MongoDb.Common;
using MongoDB.Driver;

namespace HeadHunter.Database.MongoDb.Collections.IndexKeysDefinitions
{
    public class IndustryIndexKeysDefinition : IDefiningIndexKeys<Industry>
    {
        public List<CreateIndexModel<Industry>> GetIndexKeys()
        {
            var result = new List<CreateIndexModel<Industry>>()
            {
                new CreateIndexModel<Industry>(Builders<Industry>.IndexKeys.Ascending(area => area.HeadHunterId)),
                new CreateIndexModel<Industry>(Builders<Industry>.IndexKeys.Ascending(area => area.Name))
            };

            return result;
        }
    }
}
