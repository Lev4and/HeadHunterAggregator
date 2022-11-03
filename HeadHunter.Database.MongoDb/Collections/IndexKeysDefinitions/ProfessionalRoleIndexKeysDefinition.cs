using HeadHunter.Database.MongoDb.Common;
using MongoDB.Driver;
using System.Linq.Expressions;

namespace HeadHunter.Database.MongoDb.Collections.IndexKeysDefinitions
{
    public class ProfessionalRoleIndexKeysDefinition : IDefiningIndexKeys<ProfessionalRole>
    {
        public IEnumerable<CreateIndexModel<ProfessionalRole>> GetIndexKeys()
        {
            var fields = new List<Expression<Func<ProfessionalRole, object>>>()
            {
                item => item.HeadHunterId, item => item.Name
            };

            return CreatorCreateIndexModel.Create(fields.ToArray());
        }
    }
}
