using HeadHunterAggregator.Services.Aggregator.Web.Http.HeadHunter;

namespace HeadHunterAggregator.Services.Aggregator.Tests.Web.Http.HeadHunter
{
    public class IndustriesHttpClientTests
    {
        private readonly IndustriesHttpClient _httpClient;

        public IndustriesHttpClientTests()
        {
            _httpClient = new IndustriesHttpClient();
        }

        [Fact]
        public async Task GetIndustriesAsync_ReturnNotEmptyResult()
        {
            var response = await _httpClient.GetIndustriesAsync();

            Assert.NotNull(response.Result);
            Assert.NotEmpty(response.Result);
        }
    }
}
