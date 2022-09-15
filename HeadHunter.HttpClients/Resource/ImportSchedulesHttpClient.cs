using HeadHunter.Database.MongoDb.Collections;
using HeadHunter.Database.MongoDb.Features.Schedule.Import;
using HeadHunter.Model.Common;

namespace HeadHunter.HttpClients.Resource
{
    public class ImportSchedulesHttpClient : ResourceHttpClient
    {
        public ImportSchedulesHttpClient() : base(ResourceRoutes.ImportSchedulesPath)
        {

        }

        public async Task<ResponseModel<Schedule>> Import(Models.Schedule schedule)
        {
            if (schedule == null)
            {
                throw new ArgumentNullException(nameof(schedule));
            }

            return await Post<Schedule>("", new Command(schedule));
        }
    }
}
