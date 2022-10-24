using HeadHunter.Database.MongoDb.Collections;
using HeadHunter.Model.Common;

namespace HeadHunter.HttpClients.Resource
{
    public class LanguagesHttpClient : ResourceHttpClient
    {
        public LanguagesHttpClient() : base(ResourceRoutes.LanguagesPath)
        {

        }

        public async Task<ResponseModel<List<Language>>> GetAllLanguagesAsync()
        {
            return await Get<List<Language>>(ResourceRoutes.LanguagesAllQuery);
        }
    }
}
