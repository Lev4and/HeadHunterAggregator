using HeadHunter.HttpClients.Core.ResponseModels;
using HeadHunter.HttpClients.HeadHunter.ResponseModels;

namespace HeadHunter.HttpClients.HeadHunter
{
    public class SpecializationsHttpClient : HeadHunterHttpClient, ISpecializationsHttpClient
    {
        public SpecializationsHttpClient() : base(HeadHunterRoutes.SpecializationsPath)
        {

        }

        public async Task<ResponseModel<Specialization[]>> GetSpecializationsAsync()
        {
            return await GetAsync<Specialization[]>("");
        }
    }
}
