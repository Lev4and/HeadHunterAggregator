using HeadHunter.Database.MongoDb.Collections;
using HeadHunter.Database.MongoDb.Features.Experience.Import;
using HeadHunter.Model.Common;

namespace HeadHunter.HttpClients.Resource
{
    public class ImportExperiencesHttpClient : ResourceHttpClient, IImporter<Experience, Models.Experience>
    {
        public ImportExperiencesHttpClient() : base(ResourceRoutes.ImportExperiencesPath)
        {

        }

        public async Task<ResponseModel<Experience>> ImportAsync(Models.Experience model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            return await Post<Experience>("", new Command(model));
        }
    }
}
