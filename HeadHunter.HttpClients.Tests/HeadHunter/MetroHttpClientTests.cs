using HeadHunter.HttpClients.HeadHunter;
using System.Net;

namespace HeadHunter.HttpClients.Tests.HeadHunter
{
    public class MetroHttpClientTests
    {
        private readonly MetroHttpClient _httpClient;

        public MetroHttpClientTests()
        {
            _httpClient = new MetroHttpClient();
        }

        [Fact]
        public async Task GetMetroStationsAsync_ReturnNotNullOrEmptyResult()
        {
            var response = await _httpClient.GetMetroStationsAsync();

            Assert.NotNull(response);

            Assert.NotNull(response.Result);
            Assert.NotEmpty(response.Result);

            Assert.Equal(HttpStatusCode.OK, response.Code);
        }
    }
}
