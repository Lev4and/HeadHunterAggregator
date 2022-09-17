using HeadHunter.Database.MongoDb.Collections;
using HeadHunter.Database.MongoDb.Features.WorkingTimeMode.Import;
using HeadHunter.Model.Common;

namespace HeadHunter.HttpClients.Resource
{
    public class ImportWorkingTimeModesHttpClient : ResourceHttpClient, IImporter<WorkingTimeMode, Models.WorkingTimeMode>
    {
        public ImportWorkingTimeModesHttpClient() : base(ResourceRoutes.ImportWorkingTimeModesPath)
        {

        }

        public async Task<ResponseModel<WorkingTimeMode>> ImportAsync(Models.WorkingTimeMode model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            return await Post<WorkingTimeMode>("", new Command(model));
        }
    }
}
