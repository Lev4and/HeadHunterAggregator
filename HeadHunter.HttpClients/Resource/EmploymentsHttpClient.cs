using HeadHunter.Database.MongoDb.Collections;
using HeadHunter.Model.Common;

namespace HeadHunter.HttpClients.Resource
{
    public class EmploymentsHttpClient : ResourceHttpClient
    {
        public EmploymentsHttpClient() : base(ResourceRoutes.EmploymentsPath)
        {

        }

        public async Task<ResponseModel<List<Employment>>> GetAllEmploymentsAsync()
        {
            return await Get<List<Employment>>(ResourceRoutes.EmploymentsAllQuery);
        }
    }
}
