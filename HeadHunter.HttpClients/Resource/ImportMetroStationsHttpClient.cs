using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HeadHunter.Database.MongoDb.Collections;
using HeadHunter.Database.MongoDb.Features.MetroStation.Import;
using HeadHunter.Model.Common;

namespace HeadHunter.HttpClients.Resource
{
    public class ImportMetroStationsHttpClient : ResourceHttpClient
    {
        public ImportMetroStationsHttpClient() : base(ResourceRoutes.ImportMetroStationsPath)
        {

        }

        public async Task<ResponseModel<MetroStation>> Import(Models.MetroStation metroStation)
        {
            if (metroStation == null)
            {
                throw new ArgumentNullException(nameof(metroStation));
            }

            return await Post<MetroStation>("", new Command(metroStation));
        }
    }
}
