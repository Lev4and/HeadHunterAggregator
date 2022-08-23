using HeadHunter.Model.Common;
using HeadHunter.Models;

namespace HeadHunter.HttpClients.HeadHunter
{
    public class AreasHttpClient : HeadHunterHttpClient
    {
        public AreasHttpClient(): base(HeadHunterRoutes.AreasPath)
        {

        }

        public async Task<ResponseModel<Country[]>> GetAllCountriesAsync()
        {
            return await Get<Country[]>(HeadHunterRoutes.AreasCountriesQuery);
        }

        public async Task<ResponseModel<Area[]>> GetAllAreasAsync()
        {
            return await Get<Area[]>("");
        }

        public async Task<ResponseModel<Area>> GetAreaAsync(int id)
        {
            if (id < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(id));
            }

            return await Get<Area>($"{id}");
        }
    }
}
