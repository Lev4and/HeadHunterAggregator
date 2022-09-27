using HeadHunter.Database.MongoDb.Common;
using MongoDB.Driver;

namespace HeadHunter.Database.MongoDb.Collections.IndexKeysDefinitions
{
    public class VacancyIndexKeysDefinition : IDefiningIndexKeys<Vacancy>
    {
        public List<CreateIndexModel<Vacancy>> GetIndexKeys()
        {
            var result = new List<CreateIndexModel<Vacancy>>()
            {
                new CreateIndexModel<Vacancy>(Builders<Vacancy>.IndexKeys.Ascending(area => area.HeadHunterId)),
            };

            return result;
        }
    }
}
