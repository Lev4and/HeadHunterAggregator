using HeadHunter.HttpClients.Core.ResponseModels;
using HeadHunter.HttpClients.HeadHunter.ResponseModels;

namespace HeadHunter.HttpClients.Resource.Import
{
    public class MetroHttpClient : ImportHttpClient, IMetroHttpClient
    {
        public MetroHttpClient() : base(ImportRoutes.ImportMetroPath)
        {

        }

        public async Task<ResponseModel<bool>> ImportAsync(City[] cities)
        {
            if (cities == null) throw new ArgumentNullException(nameof(cities));

            return await PostAsync<bool>("", cities);
        }
    }
}
