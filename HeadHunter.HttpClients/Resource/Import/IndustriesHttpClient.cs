using HeadHunter.HttpClients.Core.ResponseModels;
using HeadHunter.HttpClients.HeadHunter.ResponseModels;

namespace HeadHunter.HttpClients.Resource.Import
{
    public class IndustriesHttpClient : ImportHttpClient, IIndustriesHttpClient
    {
        public IndustriesHttpClient() : base(ImportRoutes.ImportIndustriesPath)
        {

        }

        public async Task<ResponseModel<bool>> ImportAsync(Industry[] industries)
        {
            if (industries == null) throw new ArgumentNullException(nameof(industries));

            return await PostAsync<bool>("", industries);
        }
    }
}
