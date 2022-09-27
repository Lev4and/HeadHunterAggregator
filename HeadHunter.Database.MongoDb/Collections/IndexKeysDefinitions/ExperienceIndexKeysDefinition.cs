using HeadHunter.Database.MongoDb.Common;
using MongoDB.Driver;

namespace HeadHunter.Database.MongoDb.Collections.IndexKeysDefinitions
{
    public class ExperienceIndexKeysDefinition : IDefiningIndexKeys<Experience>
    {
        public List<CreateIndexModel<Experience>> GetIndexKeys()
        {
            var result = new List<CreateIndexModel<Experience>>()
            {
                new CreateIndexModel<Experience>(Builders<Experience>.IndexKeys.Ascending(area => area.HeadHunterId)),
                new CreateIndexModel<Experience>(Builders<Experience>.IndexKeys.Ascending(area => area.Name))
            };

            return result;
        }
    }
}
