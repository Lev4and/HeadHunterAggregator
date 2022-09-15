using HeadHunter.Database.MongoDb.Collections;
using HeadHunter.Database.MongoDb.Features.Employer.Import;
using HeadHunter.Model.Common;

namespace HeadHunter.HttpClients.Resource
{
    public class ImportEmployersHttpClient : ResourceHttpClient
    {
        public ImportEmployersHttpClient() : base(ResourceRoutes.ImportEmployersPath)
        {

        }

        public async Task<ResponseModel<Employer>> Import(Models.Employer employer)
        {
            if (employer == null)
            {
                throw new ArgumentNullException(nameof(employer));
            }

            return await Post<Employer>("", new Command(employer));
        }
    }
}
