using HeadHunter.Database.MongoDb.Collections;
using HeadHunter.Model.Common;

namespace HeadHunter.HttpClients.Resource
{
    public class CurrenciesHttpClient : ResourceHttpClient
    {
        public CurrenciesHttpClient() : base(ResourceRoutes.CurrenciesPath)
        {

        }

        public async Task<ResponseModel<List<Currency>>> GetAllCurrenciesAsync()
        {
            return await Get<List<Currency>>(ResourceRoutes.CurrenciesAllQuery);
        }
    }
}
