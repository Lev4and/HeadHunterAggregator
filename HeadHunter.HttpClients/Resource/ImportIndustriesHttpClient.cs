using HeadHunter.Database.MongoDb.Collections;
using HeadHunter.Database.MongoDb.Features.Industry.Import;
using HeadHunter.Model.Common;

namespace HeadHunter.HttpClients.Resource
{
    public class ImportIndustriesHttpClient : ResourceHttpClient
    {
        public ImportIndustriesHttpClient() : base(ResourceRoutes.ImportIndustriesPath)
        {

        }

        public async Task<ResponseModel<Industry>> Import(Models.Industry industry)
        {
            if (industry == null)
            {
                throw new ArgumentNullException(nameof(industry));
            }

            return await Post<Industry>("", new Command(industry));
        }
    }
}
