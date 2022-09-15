using HeadHunter.Database.MongoDb.Collections;
using HeadHunter.Database.MongoDb.Features.Country.Import;
using HeadHunter.Model.Common;

namespace HeadHunter.HttpClients.Resource
{
    public class ImportCountriesHttpClient : ResourceHttpClient
    {
        public ImportCountriesHttpClient() : base(ResourceRoutes.ImportCountriesPath)
        {

        }

        public async Task<ResponseModel<Country>> Import(Models.Country country)
        {
            if (country == null)
            {
                throw new ArgumentNullException(nameof(country));
            }

            return await Post<Country>("", new Command(country));
        }
    }
}
