using HeadHunter.Database.MongoDb.Common;
using MongoDB.Driver;
using System.Linq.Expressions;

namespace HeadHunter.Database.MongoDb.Collections.IndexKeysDefinitions
{
    public class MetroLineIndexKeysDefinition : IDefiningIndexKeys<MetroLine>
    {
        public IEnumerable<CreateIndexModel<MetroLine>> GetIndexKeys()
        {
            var fields = new List<Expression<Func<MetroLine, object>>>()
            {
                item => item.AreaId, item => item.HeadHunterId, item => item.Name
            };

            return CreatorCreateIndexModel.Create(fields.ToArray());
        }
    }
}
