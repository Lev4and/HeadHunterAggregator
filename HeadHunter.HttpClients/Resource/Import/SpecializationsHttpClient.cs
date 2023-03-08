using HeadHunter.HttpClients.Core.ResponseModels;
using HeadHunter.HttpClients.HeadHunter.ResponseModels;

namespace HeadHunter.HttpClients.Resource.Import
{
    public class SpecializationsHttpClient : ImportHttpClient, ISpecializationsHttpClient
    {
        public SpecializationsHttpClient() : base(ImportRoutes.ImportSpecializationsPath)
        {

        }

        public async Task<ResponseModel<bool>> ImportAsync(Specialization[] specializations)
        {
            if (specializations == null) throw new ArgumentNullException(nameof(specializations));

            return await PostAsync<bool>("", specializations);
        }
    }
}
