using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HeadHunter.Database.MongoDb.Collections;
using HeadHunter.Database.MongoDb.Features.WorkingTimeMode.Import;
using HeadHunter.Model.Common;

namespace HeadHunter.HttpClients.Resource
{
    public class ImportWorkingTimeModesHttpClient : ResourceHttpClient
    {
        public ImportWorkingTimeModesHttpClient() : base(ResourceRoutes.ImportWorkingTimeModesPath)
        {

        }

        public async Task<ResponseModel<WorkingTimeMode>> Import(Models.WorkingTimeMode workingTimeMode)
        {
            if (workingTimeMode == null)
            {
                throw new ArgumentNullException(nameof(workingTimeMode));
            }

            return await Post<WorkingTimeMode>("", new Command(workingTimeMode));
        }
    }
}
