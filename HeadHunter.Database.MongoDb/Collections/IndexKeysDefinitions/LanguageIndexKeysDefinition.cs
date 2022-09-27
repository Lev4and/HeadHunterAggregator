using HeadHunter.Database.MongoDb.Common;
using MongoDB.Driver;

namespace HeadHunter.Database.MongoDb.Collections.IndexKeysDefinitions
{
    public class LanguageIndexKeysDefinition : IDefiningIndexKeys<Language>
    {
        public List<CreateIndexModel<Language>> GetIndexKeys()
        {
            var result = new List<CreateIndexModel<Language>>()
            {
                new CreateIndexModel<Language>(Builders<Language>.IndexKeys.Ascending(area => area.HeadHunterId)),
                new CreateIndexModel<Language>(Builders<Language>.IndexKeys.Ascending(area => area.Name))
            };

            return result;
        }
    }
}
