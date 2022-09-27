using HeadHunter.Database.MongoDb.Common;
using MongoDB.Driver;

namespace HeadHunter.Database.MongoDb.Collections.IndexKeysDefinitions
{
    public class EmploymentIndexKeysDefinition : IDefiningIndexKeys<Employment>
    {
        public List<CreateIndexModel<Employment>> GetIndexKeys()
        {
            var result = new List<CreateIndexModel<Employment>>()
            {
                new CreateIndexModel<Employment>(Builders<Employment>.IndexKeys.Ascending(area => area.HeadHunterId)),
                new CreateIndexModel<Employment>(Builders<Employment>.IndexKeys.Ascending(area => area.Name))
            };

            return result;
        }
    }
}
