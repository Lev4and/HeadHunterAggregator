using HeadHunter.Database.MongoDb.Collections;
using HeadHunter.Database.MongoDb.Features.WorkingTimeInterval.Import;
using HeadHunter.Model.Common;

namespace HeadHunter.HttpClients.Resource
{
    public class ImportWorkingTimeIntervalsHttpClient : ResourceHttpClient
    {
        public ImportWorkingTimeIntervalsHttpClient() : base(ResourceRoutes.ImportWorkingTimeIntervalsPath)
        {

        }

        public async Task<ResponseModel<WorkingTimeInterval>> Import(Models.WorkingTimeInterval workingTimeInterval)
        {
            if (workingTimeInterval == null)
            {
                throw new ArgumentNullException(nameof(workingTimeInterval));
            }

            return await Post<WorkingTimeInterval>("", new Command(workingTimeInterval));
        }
    }
}
