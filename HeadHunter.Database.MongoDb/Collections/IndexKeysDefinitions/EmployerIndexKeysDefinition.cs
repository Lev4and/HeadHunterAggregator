using HeadHunter.Database.MongoDb.Common;
using MongoDB.Driver;
using System.Linq.Expressions;

namespace HeadHunter.Database.MongoDb.Collections.IndexKeysDefinitions
{
    public class EmployerIndexKeysDefinition : IDefiningIndexKeys<Employer>
    {
        public IEnumerable<CreateIndexModel<Employer>> GetIndexKeys()
        {
            var fields = new List<Expression<Func<Employer, object>>>()
            {
                item => item.AreaId, item => item.HeadHunterId, item => item.IndustriesIds
            };

            return CreatorCreateIndexModel.Create(fields.ToArray());
        }
    }
}
