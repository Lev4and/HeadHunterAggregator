using HeadHunter.Database.MongoDb.Common;
using MongoDB.Driver;

namespace HeadHunter.Database.MongoDb.Collections.IndexKeysDefinitions
{
    public class ScheduleIndexKeysDefinition : IDefiningIndexKeys<Schedule>
    {
        public List<CreateIndexModel<Schedule>> GetIndexKeys()
        {
            var result = new List<CreateIndexModel<Schedule>>()
            {
                new CreateIndexModel<Schedule>(Builders<Schedule>.IndexKeys.Ascending(area => area.HeadHunterId)),
                new CreateIndexModel<Schedule>(Builders<Schedule>.IndexKeys.Ascending(area => area.Name))
            };

            return result;
        }
    }
}
