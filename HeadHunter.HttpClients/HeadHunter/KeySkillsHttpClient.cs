using HeadHunter.HttpClients.HeadHunter.ResponseModels;
using HeadHunter.Model.Common;
using HeadHunter.Models;

namespace HeadHunter.HttpClients.HeadHunter
{
    public class KeySkillsHttpClient : HeadHunterHttpClient
    {
        public KeySkillsHttpClient(): base(HeadHunterRoutes.KeySkillsPath)
        {

        }

        public async Task<ResponseModel<ItemsResponseModel<KeySkill>>> GetKeySkillAsync(int id)
        {
            if (id < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(id));
            }

            return await Get<ItemsResponseModel<KeySkill>>($"?id={id}");
        }

        public async Task<ResponseModel<ItemsResponseModel<KeySkill>>> GetKeySkillsAsync(int[] ids)
        {
            if (ids == null || ids.Length == 0)
            {
                throw new ArgumentNullException(nameof(ids));
            }

            if (ids.Any(id => id < 1))
            {
                throw new ArgumentOutOfRangeException(nameof(ids));
            }

            return await Get<ItemsResponseModel<KeySkill>>($"?{string.Join('&', ids.Select(id => $"id={id}"))}");
        }
    }
}
