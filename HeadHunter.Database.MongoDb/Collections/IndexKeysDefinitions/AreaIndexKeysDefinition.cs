using HeadHunter.Database.MongoDb.Common;
using MongoDB.Driver;

namespace HeadHunter.Database.MongoDb.Collections.IndexKeysDefinitions
{
    public class AreaIndexKeysDefinition : IDefiningIndexKeys<Area>
    {
        public List<CreateIndexModel<Area>> GetIndexKeys()
        {
            var result = new List<CreateIndexModel<Area>>()
            {
                new CreateIndexModel<Area>(Builders<Area>.IndexKeys.Ascending(area => area.HeadHunterId)),
                new CreateIndexModel<Area>(Builders<Area>.IndexKeys.Ascending(area => area.Name))
            };

            return result;
        }
    }
}
