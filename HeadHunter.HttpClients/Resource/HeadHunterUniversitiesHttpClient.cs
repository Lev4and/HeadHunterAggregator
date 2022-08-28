using HeadHunter.HttpClients.HeadHunter.ResponseModels;
using HeadHunter.Model.Common;
using HeadHunter.Models;

namespace HeadHunter.HttpClients.Resource
{
    public class HeadHunterUniversitiesHttpClient : ResourceHttpClient
    {
        public HeadHunterUniversitiesHttpClient() : base(ResourceRoutes.HeadHunterUniversitiesPath)
        {

        }

        public async Task<ResponseModel<ItemsResponseModel<University>>> GetUniversityAsync(int id)
        {
            if (id < ResourceConstants.HeadHunterIdLowerValue)
            {
                throw new ArgumentOutOfRangeException(nameof(id));
            }

            return await Get<ItemsResponseModel<University>>($"?{ResourceRoutes.HeadHunterUniversitiesIdQueryParam}={id}");
        }

        public async Task<ResponseModel<ItemsResponseModel<University>>> GetUniversitiesAsync(int[] ids)
        {
            if (ids == null || ids.Length == 0)
            {
                throw new ArgumentNullException(nameof(ids));
            }

            if (ids.Any(id => id < ResourceConstants.HeadHunterIdLowerValue))
            {
                throw new ArgumentOutOfRangeException(nameof(ids));
            }

            return await Get<ItemsResponseModel<University>>($"?{string.Join('&', ids.Select(id => $"{ResourceRoutes.HeadHunterUniversitiesIdQueryParam}={id}"))}");
        }

        public async Task<ResponseModel<Faculty[]>> GetAllFacultiesByUniversityIdAsync(int universityId)
        {
            if (universityId < ResourceConstants.HeadHunterIdLowerValue)
            {
                throw new ArgumentOutOfRangeException(nameof(universityId));
            }

            return await Get<Faculty[]>($"{universityId}/{ResourceRoutes.HeadHunterUniversitiesFacultiesQuery}");
        }
    }
}
