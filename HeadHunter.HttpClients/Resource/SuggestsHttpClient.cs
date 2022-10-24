using HeadHunter.Model.Common;

namespace HeadHunter.HttpClients.Resource
{
    public class SuggestsHttpClient : ResourceHttpClient
    {
        public SuggestsHttpClient() : base(ResourceRoutes.SuggestsPath)
        {

        }

        public async Task<ResponseModel<List<string>>> GetMainSuggestsAsync(string searchString)
        {
            if (string.IsNullOrEmpty(searchString))
            {
                throw new ArgumentNullException(nameof(searchString));
            }

            return await Get<List<string>>($"{ResourceRoutes.SuggestsMainQuery}?q={searchString}");
        }
    }
}
