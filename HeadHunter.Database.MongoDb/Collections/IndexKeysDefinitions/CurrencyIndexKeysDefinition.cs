using HeadHunter.Database.MongoDb.Common;
using MongoDB.Driver;
using System.Linq.Expressions;

namespace HeadHunter.Database.MongoDb.Collections.IndexKeysDefinitions
{
    public class CurrencyIndexKeysDefinition : IDefiningIndexKeys<Currency>
    {
        public IEnumerable<CreateIndexModel<Currency>> GetIndexKeys()
        {
            var fields = new List<Expression<Func<Currency, object>>>()
            {
                item => item.HeadHunterId
            };

            return CreatorCreateIndexModel.Create(fields.ToArray());
        }
    }
}
