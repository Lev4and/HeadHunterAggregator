using HeadHunterAggregator.Services.Aggregator.Web.Http.HeadHunter;

namespace HeadHunterAggregator.Services.Aggregator.Tests.Web.Http.HeadHunter
{
    public class VacanciesHttpClientTests
    {
        private readonly VacanciesHttpClient _httpClient;

        public VacanciesHttpClientTests()
        {
            _httpClient = new VacanciesHttpClient();
        }
    }
}
