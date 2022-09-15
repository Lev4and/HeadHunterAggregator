using HeadHunter.Database.MongoDb.Collections;
using HeadHunter.Database.MongoDb.Features.Experience.Import;
using HeadHunter.Model.Common;

namespace HeadHunter.HttpClients.Resource
{
    public class ImportExperiencesHttpClient : ResourceHttpClient
    {
        public ImportExperiencesHttpClient() : base(ResourceRoutes.ImportExperiencesPath)
        {

        }

        public async Task<ResponseModel<Experience>> Import(Models.Experience experience)
        {
            if (experience == null)
            {
                throw new ArgumentNullException(nameof(experience));
            }

            return await Post<Experience>("", new Command(experience));
        }
    }
}
