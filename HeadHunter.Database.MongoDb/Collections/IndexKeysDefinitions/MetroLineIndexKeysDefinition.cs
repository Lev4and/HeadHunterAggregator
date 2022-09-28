using HeadHunter.Database.MongoDb.Common;
using MongoDB.Driver;

namespace HeadHunter.Database.MongoDb.Collections.IndexKeysDefinitions
{
    public class MetroLineIndexKeysDefinition : IDefiningIndexKeys<MetroLine>
    {
        public List<CreateIndexModel<MetroLine>> GetIndexKeys()
        {
            var result = new List<CreateIndexModel<MetroLine>>()
            {
                new CreateIndexModel<MetroLine>(Builders<MetroLine>.IndexKeys.Ascending(area => area.HeadHunterId)),
                new CreateIndexModel<MetroLine>(Builders<MetroLine>.IndexKeys.Ascending(area => area.Name))
            };

            return result;
        }
    }
}
