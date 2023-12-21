using HeadHunterAggregator.Services.Aggregator.Web.Http.HeadHunter;

namespace HeadHunterAggregator.Services.Aggregator.Tests.Web.Http.HeadHunter
{
    public class LanguagesHttpClientTests
    {
        private readonly LanguagesHttpClient _httpClient;

        public LanguagesHttpClientTests()
        {
            _httpClient = new LanguagesHttpClient();
        }

        [Fact]
        public async Task GetLanguagesAsync_ReturnNotEmptyResult()
        {
            var response = await _httpClient.GetLanguagesAsync();

            Assert.NotNull(response.Result);
            Assert.NotEmpty(response.Result);
        }
    }
}
