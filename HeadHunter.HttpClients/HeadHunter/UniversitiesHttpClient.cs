using HeadHunter.HttpClients.HeadHunter.ResponseModels;
using HeadHunter.Model.Common;
using HeadHunter.Models;

namespace HeadHunter.HttpClients.HeadHunter
{
    public class UniversitiesHttpClient : HeadHunterHttpClient
    {
        public UniversitiesHttpClient(): base(HeadHunterRoutes.UniversitiesPath)
        {

        }

        public async Task<ResponseModel<ItemsResponseModel<University>>> GetUniversityAsync(int id)
        {
            if (id < HeadHunterConstants.IdLowerValue)
            {
                throw new ArgumentOutOfRangeException(nameof(id));
            }

            return await Get<ItemsResponseModel<University>>($"?{HeadHunterRoutes.UniversitiesIdQueryParam}={id}");
        }

        public async Task<ResponseModel<ItemsResponseModel<University>>> GetUniversitiesAsync(int[] ids)
        {
            if (ids == null || ids.Length == 0)
            {
                throw new ArgumentNullException(nameof(ids));
            }

            if (ids.Any(id => id < HeadHunterConstants.IdLowerValue))
            {
                throw new ArgumentOutOfRangeException(nameof(ids));
            }

            return await Get<ItemsResponseModel<University>>($"?{string.Join('&', ids.Select(id => $"{HeadHunterRoutes.UniversitiesIdQueryParam}={id}"))}");
        }

        public async Task<ResponseModel<Faculty[]>> GetAllFacultiesByUniversityIdAsync(int universityId)
        {
            if (universityId < HeadHunterConstants.IdLowerValue)
            {
                throw new ArgumentOutOfRangeException(nameof(universityId));
            }

            return await Get<Faculty[]>($"{universityId}/{HeadHunterRoutes.UniversitiesFacultiesQuery}");
        }
    }
}
