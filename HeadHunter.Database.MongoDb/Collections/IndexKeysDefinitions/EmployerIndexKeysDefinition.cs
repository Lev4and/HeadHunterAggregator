using HeadHunter.Database.MongoDb.Common;
using MongoDB.Driver;

namespace HeadHunter.Database.MongoDb.Collections.IndexKeysDefinitions
{
    public class EmployerIndexKeysDefinition : IDefiningIndexKeys<Employer>
    {
        public List<CreateIndexModel<Employer>> GetIndexKeys()
        {
            var result = new List<CreateIndexModel<Employer>>()
            {
                new CreateIndexModel<Employer>(Builders<Employer>.IndexKeys.Ascending(area => area.HeadHunterId))
            };

            return result;
        }
    }
}
