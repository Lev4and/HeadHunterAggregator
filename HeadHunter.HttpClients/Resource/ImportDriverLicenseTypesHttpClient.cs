using HeadHunter.Database.MongoDb.Collections;
using HeadHunter.Database.MongoDb.Features.DriverLicenseType.Import;
using HeadHunter.Model.Common;

namespace HeadHunter.HttpClients.Resource
{
    public class ImportDriverLicenseTypesHttpClient : ResourceHttpClient
    {
        public ImportDriverLicenseTypesHttpClient() : base(ResourceRoutes.ImportDriverLicenseTypesPath)
        {

        }

        public async Task<ResponseModel<DriverLicenseType>> Import(Models.DriverLicenseType driverLicenseType)
        {
            if (driverLicenseType == null)
            {
                throw new ArgumentNullException(nameof(driverLicenseType));
            }

            return await Post<DriverLicenseType>("", new Command(driverLicenseType));
        }
    }
}
