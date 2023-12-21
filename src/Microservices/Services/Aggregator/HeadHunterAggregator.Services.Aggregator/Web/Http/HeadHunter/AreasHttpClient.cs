using HeadHunterAggregator.Infrastructure.Web.Http;
using HeadHunterAggregator.Services.Aggregator.Web.Http.HeadHunter.DTOs;

namespace HeadHunterAggregator.Services.Aggregator.Web.Http.HeadHunter
{
    public class AreasHttpClient : HeadHunterHttpClient
    {
        public AreasHttpClient() : base(new Uri(HeadHunterRoutes.AreasUriPath, UriKind.Relative))
        {
            
        }

        public async Task<ResponseModel<IReadOnlyCollection<AreaDto>>> GetAreasAsync(
            CancellationToken cancellationToken = default)
        {
            return await GetAsync<IReadOnlyCollection<AreaDto>>("", cancellationToken);
        }
    }
}
