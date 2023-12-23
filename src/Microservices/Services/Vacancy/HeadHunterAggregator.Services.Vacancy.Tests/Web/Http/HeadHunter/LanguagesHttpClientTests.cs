using HeadHunterAggregator.Services.Vacancy.Web.Http.HeadHunter;

namespace HeadHunterAggregator.Services.Vacancy.Tests.Web.Http.HeadHunter
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
