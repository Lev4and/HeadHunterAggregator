using HeadHunter.Database.MongoDb.Collections;
using HeadHunter.Database.MongoDb.Features.ProfessionalRole.Import;
using HeadHunter.Model.Common;

namespace HeadHunter.HttpClients.Resource
{
    public class ImportProfessionalRolesHttpClient : ResourceHttpClient, IImporter<ProfessionalRole, Models.ProfessionalRole>
    {
        public ImportProfessionalRolesHttpClient() : base(ResourceRoutes.ImportProfessionalRolesPath)
        {

        }

        public async Task<ResponseModel<ProfessionalRole>> ImportAsync(Models.ProfessionalRole model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            return await Post<ProfessionalRole>("", new Command(model));
        }
    }
}
