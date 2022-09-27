using HeadHunter.Database.MongoDb.Common;
using MongoDB.Driver;

namespace HeadHunter.Database.MongoDb.Collections.IndexKeysDefinitions
{
    public class WorkingTimeIntervalIndexKeysDefinition : IDefiningIndexKeys<WorkingTimeInterval>
    {
        public List<CreateIndexModel<WorkingTimeInterval>> GetIndexKeys()
        {
            var result = new List<CreateIndexModel<WorkingTimeInterval>>()
            {
                new CreateIndexModel<WorkingTimeInterval>(Builders<WorkingTimeInterval>.IndexKeys.Ascending(area => area.HeadHunterId)),
                new CreateIndexModel<WorkingTimeInterval>(Builders<WorkingTimeInterval>.IndexKeys.Ascending(area => area.Name))
            };

            return result;
        }
    }
}
