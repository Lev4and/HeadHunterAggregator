using HeadHunter.HttpClients.HeadHunter;
using System.Net;

namespace HeadHunter.HttpClients.Tests.HeadHunter
{
    public class EmployersHttpClientTests
    {
        private readonly EmployersHttpClient _httpClient;

        public EmployersHttpClientTests()
        {
            _httpClient = new EmployersHttpClient();
        }

        [Fact]
        public async Task GetEmployerAsync_WithNegativeIdParam_ThrowException()
        {
            var action = async () => { await _httpClient.GetEmployerAsync(-1); };

            await Assert.ThrowsAsync<ArgumentOutOfRangeException>(action);
        }

        [Fact]
        public async Task GetEmployerAsync_WithZeroIdParam_ThrowException()
        {
            var action = async () => { await _httpClient.GetEmployerAsync(0); };

            await Assert.ThrowsAsync<ArgumentOutOfRangeException>(action);
        }

        [Fact]
        public async Task GetEmployerAsync_WithPositiveExistsIdParam_ReturnOkResponseWithNotNullResult()
        {
            var response = await _httpClient.GetEmployerAsync(2925151);

            Assert.NotNull(response);

            Assert.NotNull(response.Result);

            Assert.Equal(HttpStatusCode.OK, response.Code);
        }

        [Fact]
        public async Task GetEmployerAsync_WithPositiveButNotExistsIdParam_ReturnNotFoundResponseWithNotNullResult()
        {
            var response = await _httpClient.GetEmployerAsync(777);

            Assert.NotNull(response);

            Assert.NotNull(response.Result);

            Assert.Equal(HttpStatusCode.NotFound, response.Code);
        }
    }
}
