using HeadHunter.Database.MongoDb.Common;
using MongoDB.Driver;
using System.Linq.Expressions;

namespace HeadHunter.Database.MongoDb.Collections.IndexKeysDefinitions
{
    public class AreaIndexKeysDefinition : IDefiningIndexKeys<Area>
    {
        public IEnumerable<CreateIndexModel<Area>> GetIndexKeys()
        {
            var fields = new List<Expression<Func<Area, object>>>()
            {
                item => item.ParentId, item => item.HeadHunterId, item => item.HeadHunterParentId, item => item.Name
            };

            return CreatorCreateIndexModel.Create(fields.ToArray());
        }
    }
}
