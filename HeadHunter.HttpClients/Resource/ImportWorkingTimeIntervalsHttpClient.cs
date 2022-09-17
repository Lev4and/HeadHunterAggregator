using HeadHunter.Database.MongoDb.Collections;
using HeadHunter.Database.MongoDb.Features.WorkingTimeInterval.Import;
using HeadHunter.Model.Common;

namespace HeadHunter.HttpClients.Resource
{
    public class ImportWorkingTimeIntervalsHttpClient : ResourceHttpClient, IImporter<WorkingTimeInterval, Models.WorkingTimeInterval>
    {
        public ImportWorkingTimeIntervalsHttpClient() : base(ResourceRoutes.ImportWorkingTimeIntervalsPath)
        {

        }

        public async Task<ResponseModel<WorkingTimeInterval>> ImportAsync(Models.WorkingTimeInterval model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            return await Post<WorkingTimeInterval>("", new Command(model));
        }
    }
}
