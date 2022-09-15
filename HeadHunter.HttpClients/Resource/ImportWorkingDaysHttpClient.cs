using HeadHunter.Database.MongoDb.Collections;
using HeadHunter.Database.MongoDb.Features.WorkingDay.Import;
using HeadHunter.Model.Common;

namespace HeadHunter.HttpClients.Resource
{
    public class ImportWorkingDaysHttpClient : ResourceHttpClient
    {
        public ImportWorkingDaysHttpClient() : base(ResourceRoutes.ImportWorkingDaysPath)
        {

        }

        public async Task<ResponseModel<WorkingDay>> Import(Models.WorkingDay workingDay)
        {
            if (workingDay == null)
            {
                throw new ArgumentNullException(nameof(workingDay));
            }

            return await Post<WorkingDay>("", new Command(workingDay));
        }
    }
}
