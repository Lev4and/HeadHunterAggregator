using HeadHunter.Model.Common;
using HeadHunter.Models;

namespace HeadHunter.HttpClients.HeadHunter
{
    public class SpecializationsHttpClient : HeadHunterHttpClient
    {
        public SpecializationsHttpClient(): base(HeadHunterRoutes.SpecializationsPath)
        {

        }

        public async Task<ResponseModel<Specialization[]>> GetAllSpecializationsAsync()
        {
            return await Get<Specialization[]>("");
        }
    }
}
