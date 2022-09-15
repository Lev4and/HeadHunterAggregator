using HeadHunter.Database.MongoDb.Collections;
using HeadHunter.Database.MongoDb.Features.Specialization.Import;
using HeadHunter.Model.Common;

namespace HeadHunter.HttpClients.Resource
{
    public class ImportSpecializationsHttpClient : ResourceHttpClient
    {
        public ImportSpecializationsHttpClient() : base(ResourceRoutes.ImportSpecializationsPath)
        {

        }

        public async Task<ResponseModel<Specialization>> Import(Models.Specialization specialization)
        {
            if (specialization == null)
            {
                throw new ArgumentNullException(nameof(specialization));
            }

            return await Post<Specialization>("", new Command(specialization));
        }
    }
}
