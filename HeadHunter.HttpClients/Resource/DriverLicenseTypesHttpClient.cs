using HeadHunter.Database.MongoDb.Collections;
using HeadHunter.Model.Common;

namespace HeadHunter.HttpClients.Resource
{
    public class DriverLicenseTypesHttpClient : ResourceHttpClient
    {
        public DriverLicenseTypesHttpClient() : base(ResourceRoutes.DriverLicenseTypesPath)
        {

        }

        public async Task<ResponseModel<List<DriverLicenseType>>> GetAllDriverLicenseTypesAsync()
        {
            return await Get<List<DriverLicenseType>>(ResourceRoutes.DriverLicenseTypesAllQuery);
        }
    }
}
