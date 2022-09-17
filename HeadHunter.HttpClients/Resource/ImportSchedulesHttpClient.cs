using HeadHunter.Database.MongoDb.Collections;
using HeadHunter.Database.MongoDb.Features.Schedule.Import;
using HeadHunter.Model.Common;

namespace HeadHunter.HttpClients.Resource
{
    public class ImportSchedulesHttpClient : ResourceHttpClient, IImporter<Schedule, Models.Schedule>
    {
        public ImportSchedulesHttpClient() : base(ResourceRoutes.ImportSchedulesPath)
        {

        }

        public async Task<ResponseModel<Schedule>> ImportAsync(Models.Schedule model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            return await Post<Schedule>("", new Command(model));
        }
    }
}
