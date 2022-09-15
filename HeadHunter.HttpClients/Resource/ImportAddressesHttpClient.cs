using HeadHunter.Database.MongoDb.Collections;
using HeadHunter.Database.MongoDb.Features.Address.Import;
using HeadHunter.Model.Common;

namespace HeadHunter.HttpClients.Resource
{
    public class ImportAddressesHttpClient : ResourceHttpClient
    {
        public ImportAddressesHttpClient() : base(ResourceRoutes.ImportAddressesPath)
        {

        }

        public async Task<ResponseModel<Address>> Import(Models.Address address)
        {
            if (address == null)
            {
                throw new ArgumentNullException(nameof(address));
            }

            return await Post<Address>("", new Command(address));
        }
    }
}
