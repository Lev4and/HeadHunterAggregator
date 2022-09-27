using HeadHunter.Database.MongoDb.Common;
using MongoDB.Driver;

namespace HeadHunter.Database.MongoDb.Collections.IndexKeysDefinitions
{
    public class SpecializationIndexKeysDefinition : IDefiningIndexKeys<Specialization>
    {
        public List<CreateIndexModel<Specialization>> GetIndexKeys()
        {
            var result = new List<CreateIndexModel<Specialization>>()
            {
                new CreateIndexModel<Specialization>(Builders<Specialization>.IndexKeys.Ascending(area => area.HeadHunterId)),
                new CreateIndexModel<Specialization>(Builders<Specialization>.IndexKeys.Ascending(area => area.Name))
            };

            return result;
        }
    }
}
