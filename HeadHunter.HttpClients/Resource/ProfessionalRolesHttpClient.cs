using HeadHunter.Database.MongoDb.Collections;
using HeadHunter.Model.Common;

namespace HeadHunter.HttpClients.Resource
{
    public class ProfessionalRolesHttpClient : ResourceHttpClient
    {
        public ProfessionalRolesHttpClient() : base(ResourceRoutes.ProfessionalRolesPath)
        {

        }

        public async Task<ResponseModel<List<ProfessionalRole>>> GetAllProfessionalRolesAsync()
        {
            return await Get<List<ProfessionalRole>>(ResourceRoutes.ProfessionalRolesAllQuery);
        }
    }
}
