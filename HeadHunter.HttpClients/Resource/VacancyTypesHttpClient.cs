using HeadHunter.Database.MongoDb.Collections;
using HeadHunter.Model.Common;

namespace HeadHunter.HttpClients.Resource
{
    public class VacancyTypesHttpClient : ResourceHttpClient
    {
        public VacancyTypesHttpClient() : base(ResourceRoutes.VacancyTypesPath)
        {

        }

        public async Task<ResponseModel<List<VacancyType>>> GetAllVacancyTypesAsync()
        {
            return await Get<List<VacancyType>>(ResourceRoutes.VacancyTypesAllQuery);
        }
    }
}
