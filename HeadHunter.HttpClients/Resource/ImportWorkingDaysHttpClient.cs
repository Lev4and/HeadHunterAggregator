using HeadHunter.Database.MongoDb.Collections;
using HeadHunter.Database.MongoDb.Features.WorkingDay.Import;
using HeadHunter.Model.Common;

namespace HeadHunter.HttpClients.Resource
{
    public class ImportWorkingDaysHttpClient : ResourceHttpClient, IImporter<WorkingDay, Models.WorkingDay>
    {
        public ImportWorkingDaysHttpClient() : base(ResourceRoutes.ImportWorkingDaysPath)
        {

        }

        public async Task<ResponseModel<WorkingDay>> ImportAsync(Models.WorkingDay model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            return await Post<WorkingDay>("", new Command(model));
        }
    }
}
