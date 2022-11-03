using HeadHunter.Database.MongoDb.Common;
using MongoDB.Driver;
using System.Linq.Expressions;

namespace HeadHunter.Database.MongoDb.Collections.IndexKeysDefinitions
{
    public class WorkingDayIndexKeysDefinition : IDefiningIndexKeys<WorkingDay>
    {
        public IEnumerable<CreateIndexModel<WorkingDay>> GetIndexKeys()
        {
            var fields = new List<Expression<Func<WorkingDay, object>>>()
            {
                item => item.HeadHunterId, item => item.Name
            };

            return CreatorCreateIndexModel.Create(fields.ToArray());
        }
    }
}
