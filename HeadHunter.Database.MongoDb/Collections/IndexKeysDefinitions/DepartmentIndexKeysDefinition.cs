using HeadHunter.Database.MongoDb.Common;
using MongoDB.Driver;

namespace HeadHunter.Database.MongoDb.Collections.IndexKeysDefinitions
{
    public class DepartmentIndexKeysDefinition : IDefiningIndexKeys<Department>
    {
        public List<CreateIndexModel<Department>> GetIndexKeys()
        {
            var result = new List<CreateIndexModel<Department>>()
            {
                new CreateIndexModel<Department>(Builders<Department>.IndexKeys.Ascending(area => area.HeadHunterId)),
                new CreateIndexModel<Department>(Builders<Department>.IndexKeys.Ascending(area => area.Name))
            };

            return result;
        }
    }
}
