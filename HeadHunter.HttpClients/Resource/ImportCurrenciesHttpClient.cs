using HeadHunter.Database.MongoDb.Collections;
using HeadHunter.Database.MongoDb.Features.Currency.Import;
using HeadHunter.Model.Common;

namespace HeadHunter.HttpClients.Resource
{
    public class ImportCurrenciesHttpClient : ResourceHttpClient
    {
        public ImportCurrenciesHttpClient() : base(ResourceRoutes.ImportCurrenciesPath)
        {

        }

        public async Task<ResponseModel<Currency>> Import(Models.Currency currency)
        {
            if (currency == null)
            {
                throw new ArgumentNullException(nameof(currency));
            }

            return await Post<Currency>("", new Command(currency));
        }
    }
}
