using HeadHunter.Model.Common;
using HeadHunter.Models;

namespace HeadHunter.HttpClients.Resource
{
    public class HeadHunterSpecializationsHttpClient : ResourceHttpClient, IGetAll<Specialization>
    {
        public HeadHunterSpecializationsHttpClient() : base(ResourceRoutes.HeadHunterSpecializationsPath)
        {

        }

        public async Task<ResponseModel<Specialization[]>> GetAllAsync()
        {
            return await Get<Specialization[]>(ResourceRoutes.HeadHunterSpecializationsAllQuery);
        }
    }
}
