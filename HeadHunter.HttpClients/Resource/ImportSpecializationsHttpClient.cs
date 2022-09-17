using HeadHunter.Database.MongoDb.Collections;
using HeadHunter.Database.MongoDb.Features.Specialization.Import;
using HeadHunter.Model.Common;

namespace HeadHunter.HttpClients.Resource
{
    public class ImportSpecializationsHttpClient : ResourceHttpClient, IImporter<Specialization, Models.Specialization>
    {
        public ImportSpecializationsHttpClient() : base(ResourceRoutes.ImportSpecializationsPath)
        {

        }

        public async Task<ResponseModel<Specialization>> ImportAsync(Models.Specialization model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            return await Post<Specialization>("", new Command(model));
        }
    }
}
