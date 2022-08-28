using HeadHunter.HttpClients.HeadHunter.ResponseModels;
using HeadHunter.Model.Common;
using HeadHunter.Models;

namespace HeadHunter.HttpClients.Resource
{
    public class HeadHunterKeySkillsHttpClient : ResourceHttpClient
    {
        public HeadHunterKeySkillsHttpClient() : base(ResourceRoutes.HeadHunterKeySkillsPath)
        {

        }

        public async Task<ResponseModel<ItemsResponseModel<KeySkill>>> GetKeySkillAsync(int id)
        {
            if (id < ResourceConstants.HeadHunterIdLowerValue)
            {
                throw new ArgumentOutOfRangeException(nameof(id));
            }

            return await Get<ItemsResponseModel<KeySkill>>($"{id}");
        }

        public async Task<ResponseModel<ItemsResponseModel<KeySkill>>> GetKeySkillsAsync(int[] ids)
        {
            if (ids == null || ids.Length == 0)
            {
                throw new ArgumentNullException(nameof(ids));
            }

            if (ids.Any(id => id < ResourceConstants.HeadHunterIdLowerValue))
            {
                throw new ArgumentOutOfRangeException(nameof(ids));
            }

            return await Get<ItemsResponseModel<KeySkill>>($"?{string.Join('&', ids.Select(id => $"{ResourceRoutes.HeadHunterKeySkillsIdQueryParam}={id}"))}");
        }
    }
}
