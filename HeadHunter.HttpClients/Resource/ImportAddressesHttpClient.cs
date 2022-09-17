using HeadHunter.Database.MongoDb.Collections;
using HeadHunter.Database.MongoDb.Features.Address.Import;
using HeadHunter.Model.Common;

namespace HeadHunter.HttpClients.Resource
{
    public class ImportAddressesHttpClient : ResourceHttpClient, IImporter<Address, Models.Address>
    {
        public ImportAddressesHttpClient() : base(ResourceRoutes.ImportAddressesPath)
        {

        }

        public async Task<ResponseModel<Address>> ImportAsync(Models.Address model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            return await Post<Address>("", new Command(model));
        }
    }
}
