using HeadHunterAggregator.Services.Aggregator.Web.Http.HeadHunter;

namespace HeadHunterAggregator.Services.Aggregator.Tests.Web.Http.HeadHunter
{
    public class AreasHttpClientTests
    {
        private readonly AreasHttpClient _httpClient;

        public AreasHttpClientTests()
        {
            _httpClient = new AreasHttpClient();
        }

        [Fact]
        public async Task GetAreasAsync_ReturnNotEmptyResult()
        {
            var response = await _httpClient.GetAreasAsync();

            Assert.NotNull(response.Result);
            Assert.NotEmpty(response.Result);
        }
    }
}
