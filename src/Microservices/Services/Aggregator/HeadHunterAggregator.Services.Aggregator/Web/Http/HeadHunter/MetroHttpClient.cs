using HeadHunterAggregator.Infrastructure.Web.Http;
using HeadHunterAggregator.Services.Aggregator.Web.Http.HeadHunter.DTOs;

namespace HeadHunterAggregator.Services.Aggregator.Web.Http.HeadHunter
{
    public class MetroHttpClient : HeadHunterHttpClient
    {
        public MetroHttpClient() : base(new Uri(HeadHunterRoutes.MetroUriPath, UriKind.Relative))
        {
            
        }

        public async Task<ResponseModel<IReadOnlyCollection<CityDto>>> GetMetroStationsAsync(
            CancellationToken cancellationToken = default)
        {
            return await GetAsync<IReadOnlyCollection<CityDto>>("", cancellationToken);
        }
    }
}
