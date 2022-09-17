using HeadHunter.Database.MongoDb.Collections;
using HeadHunter.Database.MongoDb.Features.Currency.Import;
using HeadHunter.Model.Common;

namespace HeadHunter.HttpClients.Resource
{
    public class ImportCurrenciesHttpClient : ResourceHttpClient, IImporter<Currency, Models.Currency>
    {
        public ImportCurrenciesHttpClient() : base(ResourceRoutes.ImportCurrenciesPath)
        {

        }

        public async Task<ResponseModel<Currency>> ImportAsync(Models.Currency model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            return await Post<Currency>("", new Command(model));
        }
    }
}
