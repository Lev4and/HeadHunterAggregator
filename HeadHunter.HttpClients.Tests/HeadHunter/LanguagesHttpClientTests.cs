using HeadHunter.HttpClients.HeadHunter;
using System.Net;

namespace HeadHunter.HttpClients.Tests.HeadHunter
{
    public class LanguagesHttpClientTests
    {
        private readonly LanguagesHttpClient _httpClient;

        public LanguagesHttpClientTests()
        {
            _httpClient = new LanguagesHttpClient();
        }

        [Fact]
        public async Task GetLanguagesAsync_ReturnNotNullOrEmptyResult()
        {
            var response = await _httpClient.GetLanguagesAsync();

            Assert.NotNull(response);

            Assert.NotNull(response.Result);
            Assert.NotEmpty(response.Result);

            Assert.Equal(HttpStatusCode.OK, response.Code);
        }
    }
}
