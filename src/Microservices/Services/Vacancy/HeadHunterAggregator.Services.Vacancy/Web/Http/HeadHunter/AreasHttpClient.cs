using HeadHunterAggregator.Infrastructure.Web.Http;
using HeadHunterAggregator.Services.Vacancy.Web.Http.HeadHunter.DTOs;

namespace HeadHunterAggregator.Services.Vacancy.Web.Http.HeadHunter
{
    public class AreasHttpClient : HeadHunterHttpClient
    {
        public AreasHttpClient() : base(new Uri(HeadHunterRoutes.AreasUriPath, UriKind.Relative))
        {

        }

        public async Task<ApiResponse<IReadOnlyCollection<AreaDto>>> GetAreasAsync(
            CancellationToken cancellationToken = default)
        {
            return await GetAsync<IReadOnlyCollection<AreaDto>>("", cancellationToken);
        }
    }
}
