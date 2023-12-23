using HeadHunterAggregator.Infrastructure.Web.Http;
using HeadHunterAggregator.Services.Vacancy.Web.Http.HeadHunter.DTOs;

namespace HeadHunterAggregator.Services.Vacancy.Web.Http.HeadHunter
{
    public class IndustriesHttpClient : HeadHunterHttpClient
    {
        public IndustriesHttpClient() : base(new Uri(HeadHunterRoutes.IndustriesUriPath, UriKind.Relative))
        {

        }

        public async Task<ResponseModel<IReadOnlyCollection<IndustryDto>>> GetIndustriesAsync(
            CancellationToken cancellationToken = default)
        {
            return await GetAsync<IReadOnlyCollection<IndustryDto>>("", cancellationToken);
        }
    }
}
