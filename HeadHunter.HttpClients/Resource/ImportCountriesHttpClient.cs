using HeadHunter.Database.MongoDb.Collections;
using HeadHunter.Database.MongoDb.Features.Country.Import;
using HeadHunter.Model.Common;

namespace HeadHunter.HttpClients.Resource
{
    public class ImportCountriesHttpClient : ResourceHttpClient, IImporter<Country, Models.Country>
    {
        public ImportCountriesHttpClient() : base(ResourceRoutes.ImportCountriesPath)
        {

        }

        public async Task<ResponseModel<Country>> ImportAsync(Models.Country model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            return await Post<Country>("", new Command(model));
        }
    }
}
