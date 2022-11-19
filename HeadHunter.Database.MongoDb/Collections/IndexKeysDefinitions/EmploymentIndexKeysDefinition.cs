using HeadHunter.Database.MongoDb.Common;
using MongoDB.Driver;
using System.Linq.Expressions;

namespace HeadHunter.Database.MongoDb.Collections.IndexKeysDefinitions
{
    public class EmploymentIndexKeysDefinition : IDefiningIndexKeys<Employment>
    {
        public IEnumerable<CreateIndexModel<Employment>> GetIndexKeys()
        {
            var fields = new List<Expression<Func<Employment, object>>>()
            {
                item => item.HeadHunterId, item => item.Name
            };

            return CreatorCreateIndexModel.Create(fields.ToArray());
        }
    }
}
