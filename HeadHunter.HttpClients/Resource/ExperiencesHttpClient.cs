using HeadHunter.Database.MongoDb.Collections;
using HeadHunter.Model.Common;

namespace HeadHunter.HttpClients.Resource
{
    public class ExperiencesHttpClient : ResourceHttpClient
    {
        public ExperiencesHttpClient() : base(ResourceRoutes.ExperiencesPath)
        {

        }

        public async Task<ResponseModel<List<Experience>>> GetAllExperiencesAsync()
        {
            return await Get<List<Experience>>(ResourceRoutes.ExperiencesAllQuery);
        }
    }
}
