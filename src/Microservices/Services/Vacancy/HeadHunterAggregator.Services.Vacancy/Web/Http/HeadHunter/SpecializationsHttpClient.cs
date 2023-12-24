using HeadHunterAggregator.Infrastructure.Web.Http;
using HeadHunterAggregator.Services.Vacancy.Web.Http.HeadHunter.DTOs;

namespace HeadHunterAggregator.Services.Vacancy.Web.Http.HeadHunter
{
    public class SpecializationsHttpClient : HeadHunterHttpClient
    {
        public SpecializationsHttpClient() : base(new Uri(HeadHunterRoutes.SpecializationsUriPath, UriKind.Relative))
        {

        }

        public async Task<ApiResponse<IReadOnlyCollection<SpecializationDto>>> GetSpecializationsAsync(
            CancellationToken cancellationToken = default)
        {
            return await GetAsync<IReadOnlyCollection<SpecializationDto>>("", cancellationToken);
        }
    }
}
