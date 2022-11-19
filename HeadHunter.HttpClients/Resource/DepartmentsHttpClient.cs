using HeadHunter.Database.MongoDb.Collections;
using HeadHunter.Model.Common;

namespace HeadHunter.HttpClients.Resource
{
    public class DepartmentsHttpClient : ResourceHttpClient
    {
        public DepartmentsHttpClient() : base(ResourceRoutes.DepartmentsPath)
        {

        }

        public async Task<ResponseModel<List<Department>>> GetAllDepartmentsAsync()
        {
            return await Get<List<Department>>(ResourceRoutes.DepartmentsAllQuery);
        }
    }
}
