using HeadHunter.Database.MongoDb.Common;
using MongoDB.Driver;
using System.Linq.Expressions;

namespace HeadHunter.Database.MongoDb.Collections.IndexKeysDefinitions
{
    public class MetroStationIndexKeysDefinition : IDefiningIndexKeys<MetroStation>
    {
        public IEnumerable<CreateIndexModel<MetroStation>> GetIndexKeys()
        {
            var fields = new List<Expression<Func<MetroStation, object>>>()
            {
                item => item.MetroLineId, item => item.HeadHunterId, item => item.Name
            };

            return CreatorCreateIndexModel.Create(fields.ToArray());
        }
    }
}
