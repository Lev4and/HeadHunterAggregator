using HeadHunter.Database.MongoDb.Common;
using MongoDB.Driver;

namespace HeadHunter.Database.MongoDb.Collections.IndexKeysDefinitions
{
    public class WorkingDayIndexKeysDefinition : IDefiningIndexKeys<WorkingDay>
    {
        public List<CreateIndexModel<WorkingDay>> GetIndexKeys()
        {
            var result = new List<CreateIndexModel<WorkingDay>>()
            {
                new CreateIndexModel<WorkingDay>(Builders<WorkingDay>.IndexKeys.Ascending(area => area.HeadHunterId)),
                new CreateIndexModel<WorkingDay>(Builders<WorkingDay>.IndexKeys.Ascending(area => area.Name))
            };

            return result;
        }
    }
}
