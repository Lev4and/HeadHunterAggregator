using HeadHunterAggregator.Services.Aggregator.Web.Http.HeadHunter;

namespace HeadHunterAggregator.Services.Aggregator.Tests.Web.Http.HeadHunter
{
    public class DictionariesHttpClientTests
    {
        private readonly DictionariesHttpClient _httpClient;

        public DictionariesHttpClientTests()
        {
            _httpClient = new DictionariesHttpClient();
        }

        [Fact]
        public async Task GetDictionariesAsync_ReturnNotNullResult()
        {
            var response = await _httpClient.GetDictionariesAsync();

            Assert.NotNull(response.Result);
        }
    }
}
