using HeadHunter.Model.Common;
using HeadHunter.Models;

namespace HeadHunter.HttpClients.Resource
{
    public class HeadHunterSpecializationsHttpClient : ResourceHttpClient
    {
        public HeadHunterSpecializationsHttpClient() : base(ResourceRoutes.HeadHunterSpecializationsPath)
        {

        }

        public async Task<ResponseModel<Specialization[]>> GetAllSpecializationsAsync()
        {
            return await Get<Specialization[]>(ResourceRoutes.HeadHunterSpecializationsAllQuery);
        }
    }
}
