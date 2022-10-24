using HeadHunter.Database.MongoDb.Collections;
using HeadHunter.Model.Common;

namespace HeadHunter.HttpClients.Resource
{
    public class SchedulesHttpClient : ResourceHttpClient
    {
        public SchedulesHttpClient() : base(ResourceRoutes.SchedulesPath)
        {

        }

        public async Task<ResponseModel<List<Schedule>>> GetAllSchedulesAsync()
        {
            return await Get<List<Schedule>>(ResourceRoutes.SchedulesAllQuery);
        }
    }
}
