using HeadHunter.Database.MongoDb.Common;
using MongoDB.Driver;
using System.Linq.Expressions;

namespace HeadHunter.Database.MongoDb.Collections.IndexKeysDefinitions
{
    public class SpecializationIndexKeysDefinition : IDefiningIndexKeys<Specialization>
    {
        public IEnumerable<CreateIndexModel<Specialization>> GetIndexKeys()
        {
            var fields = new List<Expression<Func<Specialization, object>>>()
            {
                item => item.ParentId, item => item.HeadHunterId, item => item.HeadHunterParentId, item => item.Name
            };

            return CreatorCreateIndexModel.Create(fields.ToArray());
        }
    }
}
