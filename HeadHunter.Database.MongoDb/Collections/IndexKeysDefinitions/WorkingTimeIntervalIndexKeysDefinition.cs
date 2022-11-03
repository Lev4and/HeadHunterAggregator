using HeadHunter.Database.MongoDb.Common;
using MongoDB.Driver;
using System.Linq.Expressions;

namespace HeadHunter.Database.MongoDb.Collections.IndexKeysDefinitions
{
    public class WorkingTimeIntervalIndexKeysDefinition : IDefiningIndexKeys<WorkingTimeInterval>
    {
        public IEnumerable<CreateIndexModel<WorkingTimeInterval>> GetIndexKeys()
        {
            var fields = new List<Expression<Func<WorkingTimeInterval, object>>>()
            {
                item => item.HeadHunterId, item => item.Name
            };

            return CreatorCreateIndexModel.Create(fields.ToArray());
        }
    }
}
