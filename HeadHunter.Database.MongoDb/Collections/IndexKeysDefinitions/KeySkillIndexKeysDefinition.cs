using HeadHunter.Database.MongoDb.Common;
using MongoDB.Driver;
using System.Linq.Expressions;

namespace HeadHunter.Database.MongoDb.Collections.IndexKeysDefinitions
{
    public class KeySkillIndexKeysDefinition : IDefiningIndexKeys<KeySkill>
    {
        public IEnumerable<CreateIndexModel<KeySkill>> GetIndexKeys()
        {
            var fields = new List<Expression<Func<KeySkill, object>>>()
            {
                item => item.Name
            };

            return CreatorCreateIndexModel.Create(fields.ToArray());
        }
    }
}
