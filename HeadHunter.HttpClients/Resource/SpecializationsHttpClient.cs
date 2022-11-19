using HeadHunter.Database.MongoDb.Collections;
using HeadHunter.Model.Common;

namespace HeadHunter.HttpClients.Resource
{
    public class SpecializationsHttpClient : ResourceHttpClient
    {
        public SpecializationsHttpClient() : base(ResourceRoutes.SpecializationsPath)
        {

        }

        public async Task<ResponseModel<List<Specialization>>> GetAllSpecializationsAsync()
        {
            return await Get<List<Specialization>>(ResourceRoutes.SpecializationsAllQuery);
        }
    }
}
