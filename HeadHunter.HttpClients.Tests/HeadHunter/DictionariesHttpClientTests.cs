using HeadHunter.HttpClients.HeadHunter;
using System.Net;

namespace HeadHunter.HttpClients.Tests.HeadHunter
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

            Assert.NotNull(response);

            Assert.NotNull(response.Result);

            Assert.Equal(HttpStatusCode.OK, response.Code);
        }
    }
}
