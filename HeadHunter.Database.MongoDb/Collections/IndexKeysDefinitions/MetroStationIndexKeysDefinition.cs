using HeadHunter.Database.MongoDb.Common;
using MongoDB.Driver;

namespace HeadHunter.Database.MongoDb.Collections.IndexKeysDefinitions
{
    public class MetroStationIndexKeysDefinition : IDefiningIndexKeys<MetroStation>
    {
        public List<CreateIndexModel<MetroStation>> GetIndexKeys()
        {
            var result = new List<CreateIndexModel<MetroStation>>()
            {
                new CreateIndexModel<MetroStation>(Builders<MetroStation>.IndexKeys.Ascending(area => area.HeadHunterId)),
                new CreateIndexModel<MetroStation>(Builders<MetroStation>.IndexKeys.Ascending(area => area.Name))
            };

            return result;
        }
    }
}
