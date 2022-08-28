using HeadHunter.Model.Common;
using HeadHunter.Models;

namespace HeadHunter.HttpClients.HeadHunter
{
    public class MetroHttpClient : HeadHunterHttpClient
    {
        public MetroHttpClient(): base(HeadHunterRoutes.MetroPath)
        {

        }

        public async Task<ResponseModel<City[]>> GetAllStationsMetroAsync()
        {
            return await Get<City[]>("");
        }

        public async Task<ResponseModel<City>> GetAllStationsMetroByCityIdAsync(int cityId)
        {
            if (cityId < HeadHunterConstants.IdLowerValue)
            {
                throw new ArgumentOutOfRangeException(nameof(cityId));
            }

            return await Get<City>($"{cityId}");
        }
    }
}
