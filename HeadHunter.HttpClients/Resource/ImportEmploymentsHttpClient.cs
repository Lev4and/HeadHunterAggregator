using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HeadHunter.Database.MongoDb.Collections;
using HeadHunter.Database.MongoDb.Features.Employment.Import;
using HeadHunter.Model.Common;

namespace HeadHunter.HttpClients.Resource
{
    public class ImportEmploymentsHttpClient : ResourceHttpClient
    {
        public ImportEmploymentsHttpClient() : base(ResourceRoutes.ImportEmploymentsPath)
        {

        }

        public async Task<ResponseModel<Employment>> Import(Models.Employment employment)
        {
            if (employment == null)
            {
                throw new ArgumentNullException(nameof(employment));
            }

            return await Post<Employment>("", new Command(employment));
        }
    }
}
