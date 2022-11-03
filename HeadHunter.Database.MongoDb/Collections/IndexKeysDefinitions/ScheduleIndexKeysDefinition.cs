using HeadHunter.Database.MongoDb.Common;
using MongoDB.Driver;
using System.Linq.Expressions;

namespace HeadHunter.Database.MongoDb.Collections.IndexKeysDefinitions
{
    public class ScheduleIndexKeysDefinition : IDefiningIndexKeys<Schedule>
    {
        public IEnumerable<CreateIndexModel<Schedule>> GetIndexKeys()
        {
            var fields = new List<Expression<Func<Schedule, object>>>()
            {
                item => item.HeadHunterId, item => item.Name
            };

            return CreatorCreateIndexModel.Create(fields.ToArray());
        }
    }
}
