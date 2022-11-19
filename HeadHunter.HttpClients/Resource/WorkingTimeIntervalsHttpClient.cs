using HeadHunter.Database.MongoDb.Collections;
using HeadHunter.Model.Common;

namespace HeadHunter.HttpClients.Resource
{
    public class WorkingTimeIntervalsHttpClient : ResourceHttpClient
    {
        public WorkingTimeIntervalsHttpClient() : base(ResourceRoutes.WorkingTimeIntervalsPath)
        {

        }

        public async Task<ResponseModel<List<WorkingTimeInterval>>> GetAllWorkingTimeIntervalsAsync()
        {
            return await Get<List<WorkingTimeInterval>>(ResourceRoutes.WorkingTimeIntervalsAllQuery);
        }
    }
}
