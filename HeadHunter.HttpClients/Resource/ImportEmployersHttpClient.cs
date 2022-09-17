using HeadHunter.Database.MongoDb.Collections;
using HeadHunter.Database.MongoDb.Features.Employer.Import;
using HeadHunter.Model.Common;

namespace HeadHunter.HttpClients.Resource
{
    public class ImportEmployersHttpClient : ResourceHttpClient, IImporter<Employer, Models.Employer>
    {
        public ImportEmployersHttpClient() : base(ResourceRoutes.ImportEmployersPath)
        {

        }

        public async Task<ResponseModel<Employer>> ImportAsync(Models.Employer model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            return await Post<Employer>("", new Command(model));
        }
    }
}
