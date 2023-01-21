using HeadHunter.HttpClients.HeadHunter;
using System.Net;

namespace HeadHunter.HttpClients.Tests.HeadHunter
{
    public class AreasHttpClientTests
    {
        private readonly AreasHttpClient _httpClient;

        public AreasHttpClientTests()
        {
            _httpClient = new AreasHttpClient();
        }

        [Fact]
        public async Task GetAreasAsync_ReturnNotNullOrEmptyResult()
        {
            var response = await _httpClient.GetAreasAsync();

            Assert.NotNull(response);

            Assert.NotNull(response.Result);
            Assert.NotEmpty(response.Result);

            Assert.Equal(HttpStatusCode.OK, response.Code);
        }
    }
}
