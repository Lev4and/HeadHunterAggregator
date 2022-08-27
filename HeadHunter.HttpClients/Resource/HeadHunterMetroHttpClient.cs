using HeadHunter.Model.Common;
using HeadHunter.Models;

namespace HeadHunter.HttpClients.Resource
{
    public class HeadHunterMetroHttpClient : ResourceHttpClient
    {
        public HeadHunterMetroHttpClient() : base(ResourceRoutes.HeadHunterMetroPath)
        {

        }

        public async Task<ResponseModel<City[]>> GetAllStationsMetroAsync()
        {
            return await Get<City[]>(ResourceRoutes.HeadHunterMetroAllQuery);
        }

        public async Task<ResponseModel<City>> GetAllStationsMetroByCityIdAsync(int cityId)
        {
            if (cityId < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(cityId));
            }

            return await Get<City>($"?cityId={cityId}");
        }
    }
}
