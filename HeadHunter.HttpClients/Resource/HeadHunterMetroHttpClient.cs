using HeadHunter.Model.Common;
using HeadHunter.Models;

namespace HeadHunter.HttpClients.Resource
{
    public class HeadHunterMetroHttpClient : ResourceHttpClient, IGetAll<City>
    {
        public HeadHunterMetroHttpClient() : base(ResourceRoutes.HeadHunterMetroPath)
        {

        }

        public async Task<ResponseModel<City[]>> GetAllAsync()
        {
            return await Get<City[]>(ResourceRoutes.HeadHunterMetroAllQuery);
        }

        public async Task<ResponseModel<City>> GetAllStationsMetroByCityIdAsync(int cityId)
        {
            if (cityId < ResourceConstants.HeadHunterIdLowerValue)
            {
                throw new ArgumentOutOfRangeException(nameof(cityId));
            }

            return await Get<City>($"?{ResourceRoutes.HeadHunterMetroAllStationsCityIdQueryParam}={cityId}");
        }
    }
}
