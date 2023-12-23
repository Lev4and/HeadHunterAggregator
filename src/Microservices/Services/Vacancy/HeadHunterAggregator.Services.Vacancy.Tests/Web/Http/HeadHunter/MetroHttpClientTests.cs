using HeadHunterAggregator.Services.Vacancy.Web.Http.HeadHunter;

namespace HeadHunterAggregator.Services.Vacancy.Tests.Web.Http.HeadHunter
{
    public class MetroHttpClientTests
    {
        private readonly MetroHttpClient _httpClient;

        public MetroHttpClientTests()
        {
            _httpClient = new MetroHttpClient();
        }

        [Fact]
        public async Task GetMetroStationsAsync_ReturnNotEmptyResult()
        {
            var response = await _httpClient.GetMetroStationsAsync();

            Assert.NotNull(response.Result);
            Assert.NotEmpty(response.Result);
        }
    }
}
