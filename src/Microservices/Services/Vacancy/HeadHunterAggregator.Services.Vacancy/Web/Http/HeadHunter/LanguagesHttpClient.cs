using HeadHunterAggregator.Infrastructure.Web.Http;
using HeadHunterAggregator.Services.Vacancy.Web.Http.HeadHunter.DTOs;

namespace HeadHunterAggregator.Services.Vacancy.Web.Http.HeadHunter
{
    public class LanguagesHttpClient : HeadHunterHttpClient
    {
        public LanguagesHttpClient() : base(new Uri(HeadHunterRoutes.LanguagesUriPath, UriKind.Relative))
        {

        }

        public async Task<ResponseModel<IReadOnlyCollection<LanguageDto>>> GetLanguagesAsync(
            CancellationToken cancellationToken = default)
        {
            return await GetAsync<IReadOnlyCollection<LanguageDto>>("", cancellationToken);
        }
    }
}
