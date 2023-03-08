using HeadHunter.HttpClients.Core.ResponseModels;
using HeadHunter.HttpClients.HeadHunter.ResponseModels;

namespace HeadHunter.HttpClients.Resource.Import
{
    public class AreasHttpClient : ImportHttpClient, IAreasHttpClient
    {
        public AreasHttpClient() : base(ImportRoutes.ImportAreasPath)
        {

        }

        public async Task<ResponseModel<bool>> ImportAsync(Area[] areas)
        {
            if (areas == null) throw new ArgumentNullException(nameof(areas));

            return await PostAsync<bool>("", areas);
        }
    }
}
