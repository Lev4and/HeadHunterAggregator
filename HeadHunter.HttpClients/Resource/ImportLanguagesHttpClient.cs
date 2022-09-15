using HeadHunter.Database.MongoDb.Collections;
using HeadHunter.Database.MongoDb.Features.Language.Import;
using HeadHunter.Model.Common;

namespace HeadHunter.HttpClients.Resource
{
    public class ImportLanguagesHttpClient : ResourceHttpClient
    {
        public ImportLanguagesHttpClient() : base(ResourceRoutes.ImportLanguagesPath)
        {

        }

        public async Task<ResponseModel<Language>> Import(Models.Language language)
        {
            if (language == null)
            {
                throw new ArgumentNullException(nameof(language));
            }

            return await Post<Language>("", new Command(language));
        }
    }
}
