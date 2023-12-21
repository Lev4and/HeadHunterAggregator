using HeadHunterAggregator.Infrastructure.Web.Http;
using HeadHunterAggregator.Services.Aggregator.Web.Http.HeadHunter.DTOs;

namespace HeadHunterAggregator.Services.Aggregator.Web.Http.HeadHunter
{
    public class DictionariesHttpClient : HeadHunterHttpClient
    {
        public DictionariesHttpClient() : base(new Uri(HeadHunterRoutes.DictionariesUriPath, UriKind.Relative))
        {
            
        }

        public async Task<ResponseModel<DictionariesDto>> GetDictionariesAsync(
            CancellationToken cancellationToken = default)
        {
            return await GetAsync<DictionariesDto>("", cancellationToken);
        }
    }
}
