using HeadHunter.Database.MongoDb.Collections;
using HeadHunter.Database.MongoDb.Features.Language.Import;
using HeadHunter.Model.Common;

namespace HeadHunter.HttpClients.Resource
{
    public class ImportLanguagesHttpClient : ResourceHttpClient, IImporter<Language, Models.Language>
    {
        public ImportLanguagesHttpClient() : base(ResourceRoutes.ImportLanguagesPath)
        {

        }

        public async Task<ResponseModel<Language>> ImportAsync(Models.Language model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            return await Post<Language>("", new Command(model));
        }
    }
}
