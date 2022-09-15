using HeadHunter.Database.MongoDb.Collections;
using HeadHunter.Database.MongoDb.Features.ProfessionalRole.Import;
using HeadHunter.Model.Common;

namespace HeadHunter.HttpClients.Resource
{
    public class ImportProfessionalRolesHttpClient : ResourceHttpClient
    {
        public ImportProfessionalRolesHttpClient() : base(ResourceRoutes.ImportProfessionalRolesPath)
        {

        }

        public async Task<ResponseModel<ProfessionalRole>> Import(Models.ProfessionalRole professionalRole)
        {
            if (professionalRole == null)
            {
                throw new ArgumentNullException(nameof(professionalRole));
            }

            return await Post<ProfessionalRole>("", new Command(professionalRole));
        }
    }
}
