using HeadHunter.Database.MongoDb.Common;
using MongoDB.Driver;
using System.Linq.Expressions;

namespace HeadHunter.Database.MongoDb.Collections.IndexKeysDefinitions
{
    public class VacancyTypeIndexKeysDefinition : IDefiningIndexKeys<VacancyType>
    {
        public IEnumerable<CreateIndexModel<VacancyType>> GetIndexKeys()
        {
            var fields = new List<Expression<Func<VacancyType, object>>>()
            {
                item => item.HeadHunterId, item => item.Name
            };

            return CreatorCreateIndexModel.Create(fields.ToArray());
        }
    }
}
