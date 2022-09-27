using HeadHunter.Database.MongoDb.Common;
using MongoDB.Driver;

namespace HeadHunter.Database.MongoDb.Collections.IndexKeysDefinitions
{
    public class WorkingTimeModeIndexKeysDefinition : IDefiningIndexKeys<WorkingTimeMode>
    {
        public List<CreateIndexModel<WorkingTimeMode>> GetIndexKeys()
        {
            var result = new List<CreateIndexModel<WorkingTimeMode>>()
            {
                new CreateIndexModel<WorkingTimeMode>(Builders<WorkingTimeMode>.IndexKeys.Ascending(area => area.HeadHunterId)),
                new CreateIndexModel<WorkingTimeMode>(Builders<WorkingTimeMode>.IndexKeys.Ascending(area => area.Name))
            };

            return result;
        }
    }
}
