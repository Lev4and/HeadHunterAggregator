using HeadHunter.Database.MongoDb.Common;
using MongoDB.Driver;

namespace HeadHunter.Database.MongoDb.Collections.IndexKeysDefinitions
{
    public class KeySkillIndexKeysDefinition : IDefiningIndexKeys<KeySkill>
    {
        public List<CreateIndexModel<KeySkill>> GetIndexKeys()
        {
            var result = new List<CreateIndexModel<KeySkill>>()
            {
                new CreateIndexModel<KeySkill>(Builders<KeySkill>.IndexKeys.Ascending(area => area.Name))
            };

            return result;
        }
    }
}
