using HeadHunterAggregator.Infrastructure.Web.Http;
using HeadHunterAggregator.Services.Vacancy.Web.Http.HeadHunter.DTOs;

namespace HeadHunterAggregator.Services.Vacancy.Web.Http.HeadHunter
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
