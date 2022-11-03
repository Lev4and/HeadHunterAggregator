using HeadHunter.Database.MongoDb.Common;
using MongoDB.Driver;
using System.Linq.Expressions;

namespace HeadHunter.Database.MongoDb.Collections.IndexKeysDefinitions
{
    public class LanguageIndexKeysDefinition : IDefiningIndexKeys<Language>
    {
        public IEnumerable<CreateIndexModel<Language>> GetIndexKeys()
        {
            var fields = new List<Expression<Func<Language, object>>>()
            {
                item => item.HeadHunterId, item => item.Name
            };

            return CreatorCreateIndexModel.Create(fields.ToArray());
        }
    }
}
