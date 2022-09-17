using HeadHunter.Database.MongoDb.Collections;
using HeadHunter.Database.MongoDb.Features.DriverLicenseType.Import;
using HeadHunter.Model.Common;

namespace HeadHunter.HttpClients.Resource
{
    public class ImportDriverLicenseTypesHttpClient : ResourceHttpClient, IImporter<DriverLicenseType, Models.DriverLicenseType>
    {
        public ImportDriverLicenseTypesHttpClient() : base(ResourceRoutes.ImportDriverLicenseTypesPath)
        {

        }

        public async Task<ResponseModel<DriverLicenseType>> ImportAsync(Models.DriverLicenseType model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            return await Post<DriverLicenseType>("", new Command(model));
        }
    }
}
