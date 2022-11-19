using HeadHunter.Database.MongoDb.Collections;
using HeadHunter.Model.Common;

namespace HeadHunter.HttpClients.Resource
{
    public class WorkingTimeModesHttpClient : ResourceHttpClient
    {
        public WorkingTimeModesHttpClient() : base(ResourceRoutes.WorkingTimeModesPath)
        {

        }

        public async Task<ResponseModel<List<WorkingTimeMode>>> GetAllWorkingTimeModesAsync()
        {
            return await Get<List<WorkingTimeMode>>(ResourceRoutes.WorkingTimeModesAllQuery);
        }
    }
}
