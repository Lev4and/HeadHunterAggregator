using HeadHunter.Database.MongoDb.Collections;
using HeadHunter.Database.MongoDb.Features.Department.Import;
using HeadHunter.Model.Common;

namespace HeadHunter.HttpClients.Resource
{
    public class ImportDepartmentsHttpClient : ResourceHttpClient
    {
        public ImportDepartmentsHttpClient() : base(ResourceRoutes.ImportDepartmentsPath)
        {

        }

        public async Task<ResponseModel<Department>> Import(Models.Department department)
        {
            if (department == null)
            {
                throw new ArgumentNullException(nameof(department));
            }

            return await Post<Department>("", new Command(department));
        }
    }
}
