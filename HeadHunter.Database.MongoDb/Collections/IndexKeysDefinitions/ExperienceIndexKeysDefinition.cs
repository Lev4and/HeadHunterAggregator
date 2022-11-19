using HeadHunter.Database.MongoDb.Common;
using MongoDB.Driver;
using System.Linq.Expressions;

namespace HeadHunter.Database.MongoDb.Collections.IndexKeysDefinitions
{
    public class ExperienceIndexKeysDefinition : IDefiningIndexKeys<Experience>
    {
        public IEnumerable<CreateIndexModel<Experience>> GetIndexKeys()
        {
            var fields = new List<Expression<Func<Experience, object>>>()
            {
                item => item.HeadHunterId, item => item.Name
            };

            return CreatorCreateIndexModel.Create(fields.ToArray());
        }
    }
}
