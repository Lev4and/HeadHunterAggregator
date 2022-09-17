using HeadHunter.Database.MongoDb.Collections;
using HeadHunter.Database.MongoDb.Features.Department.Import;
using HeadHunter.Model.Common;

namespace HeadHunter.HttpClients.Resource
{
    public class ImportDepartmentsHttpClient : ResourceHttpClient, IImporter<Department, Models.Department>
    {
        public ImportDepartmentsHttpClient() : base(ResourceRoutes.ImportDepartmentsPath)
        {

        }

        public async Task<ResponseModel<Department>> ImportAsync(Models.Department model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            return await Post<Department>("", new Command(model));
        }
    }
}
