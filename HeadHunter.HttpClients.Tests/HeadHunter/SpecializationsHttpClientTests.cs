using HeadHunter.HttpClients.HeadHunter;
using System.Net;

namespace HeadHunter.HttpClients.Tests.HeadHunter
{
    public class SpecializationsHttpClientTests
    {
        private readonly SpecializationsHttpClient _httpClient;

        public SpecializationsHttpClientTests()
        {
            _httpClient = new SpecializationsHttpClient();
        }

        [Fact]
        public async Task GetSpecializationsAsync_ReturnNotNullOrEmptyResult()
        {
            var response = await _httpClient.GetSpecializationsAsync();

            Assert.NotNull(response);

            Assert.NotNull(response.Result);
            Assert.NotEmpty(response.Result);

            Assert.Equal(HttpStatusCode.OK, response.Code);
        }
    }
}
