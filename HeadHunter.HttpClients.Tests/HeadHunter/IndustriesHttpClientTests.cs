using HeadHunter.HttpClients.HeadHunter;
using System.Net;

namespace HeadHunter.HttpClients.Tests.HeadHunter
{
    public class IndustriesHttpClientTests
    {
        private readonly IndustriesHttpClient _httpClient;

        public IndustriesHttpClientTests()
        {
            _httpClient = new IndustriesHttpClient();
        }

        [Fact]
        public async Task GetIndustriesAsync_ReturnNotNullOrEmptyResult()
        {
            var response = await _httpClient.GetIndustriesAsync();

            Assert.NotNull(response);

            Assert.NotNull(response.Result);
            Assert.NotEmpty(response.Result);

            Assert.Equal(HttpStatusCode.OK, response.Code);
        }
    }
}
