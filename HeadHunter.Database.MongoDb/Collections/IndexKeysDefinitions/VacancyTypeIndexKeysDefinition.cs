using HeadHunter.Database.MongoDb.Common;
using MongoDB.Driver;

namespace HeadHunter.Database.MongoDb.Collections.IndexKeysDefinitions
{
    public class VacancyTypeIndexKeysDefinition : IDefiningIndexKeys<VacancyType>
    {
        public List<CreateIndexModel<VacancyType>> GetIndexKeys()
        {
            var result = new List<CreateIndexModel<VacancyType>>()
            {
                new CreateIndexModel<VacancyType>(Builders<VacancyType>.IndexKeys.Ascending(area => area.HeadHunterId)),
                new CreateIndexModel<VacancyType>(Builders<VacancyType>.IndexKeys.Ascending(area => area.Name))
            };

            return result;
        }
    }
}
