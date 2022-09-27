using HeadHunter.Database.MongoDb.Common;
using MongoDB.Driver;

namespace HeadHunter.Database.MongoDb.Collections.IndexKeysDefinitions
{
    public class ProfessionalRoleIndexKeysDefinition : IDefiningIndexKeys<ProfessionalRole>
    {
        public List<CreateIndexModel<ProfessionalRole>> GetIndexKeys()
        {
            var result = new List<CreateIndexModel<ProfessionalRole>>()
            {
                new CreateIndexModel<ProfessionalRole>(Builders<ProfessionalRole>.IndexKeys.Ascending(area => area.HeadHunterId)),
                new CreateIndexModel<ProfessionalRole>(Builders<ProfessionalRole>.IndexKeys.Ascending(area => area.Name))
            };

            return result;
        }
    }
}
