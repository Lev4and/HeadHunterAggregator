using HeadHunter.Database.MongoDb.Collections;
using HeadHunter.Model.Common;

namespace HeadHunter.HttpClients.Resource
{
    public class WorkingDaysHttpClient : ResourceHttpClient
    {
        public WorkingDaysHttpClient() : base(ResourceRoutes.WorkingDaysPath)
        {

        }

        public async Task<ResponseModel<List<WorkingDay>>> GetAllWorkingDaysAsync()
        {
            return await Get<List<WorkingDay>>(ResourceRoutes.WorkingDaysAllQuery);
        }
    }
}
