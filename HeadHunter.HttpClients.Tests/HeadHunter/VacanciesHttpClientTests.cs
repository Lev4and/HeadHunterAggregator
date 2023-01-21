using HeadHunter.HttpClients.HeadHunter;
using System.Net;

namespace HeadHunter.HttpClients.Tests.HeadHunter
{
    public class VacanciesHttpClientTests
    {
        private readonly VacanciesHttpClient _httpClient;

        public VacanciesHttpClientTests()
        {
            _httpClient = new VacanciesHttpClient();
        }

        [Fact]
        public async Task GetVacanciesAsync_WithNegativePageParam_ThrowException()
        {
            var action = async () => { await _httpClient.GetVacanciesAsync(-1, 1, DateTime.UtcNow, DateTime.UtcNow); };

            await Assert.ThrowsAsync<ArgumentOutOfRangeException>(action);
        }

        [Fact]
        public async Task GetVacanciesAsync_WithZeroPageParam_ThrowException()
        {
            var action = async () => { await _httpClient.GetVacanciesAsync(0, 1, DateTime.UtcNow, DateTime.UtcNow); };

            await Assert.ThrowsAsync<ArgumentOutOfRangeException>(action);
        }

        [Fact]
        public async Task GetVacanciesAsync_WithHugePageParam_ThrowException()
        {
            var action = async () => { await _httpClient.GetVacanciesAsync(2000, 1, DateTime.UtcNow, DateTime.UtcNow); };

            await Assert.ThrowsAsync<ArgumentOutOfRangeException>(action);
        }

        [Fact]
        public async Task GetVacanciesAsync_WithNegativePerPageParam_ThrowException()
        {
            var action = async () => { await _httpClient.GetVacanciesAsync(1, -1, DateTime.UtcNow, DateTime.UtcNow); };

            await Assert.ThrowsAsync<ArgumentOutOfRangeException>(action);
        }

        [Fact]
        public async Task GetVacanciesAsync_WithZeroPerPageParam_ThrowException()
        {
            var action = async () => { await _httpClient.GetVacanciesAsync(1, 0, DateTime.UtcNow, DateTime.UtcNow); };

            await Assert.ThrowsAsync<ArgumentOutOfRangeException>(action);
        }

        [Fact]
        public async Task GetVacanciesAsync_WithHugePerPageParam_ThrowException()
        {
            var action = async () => { await _httpClient.GetVacanciesAsync(1, 101, DateTime.UtcNow, DateTime.UtcNow); };

            await Assert.ThrowsAsync<ArgumentOutOfRangeException>(action);
        }

        [Fact]
        public async Task GetVacanciesAsync_WhereDateFromParamGreaterThanDateToParam_ThrowException()
        {
            var action = async () => { await _httpClient.GetVacanciesAsync(1, 100, DateTime.UtcNow.AddMinutes(1), 
                DateTime.UtcNow); 
            };

            await Assert.ThrowsAsync<ArgumentOutOfRangeException>(action);
        }

        [Fact]
        public async Task GetVacanciesAsync_WhereEveryParamIsValid_ReturnNotNullOrEmptyResult()
        {
            var response = await _httpClient.GetVacanciesAsync(1, 100, DateTime.UtcNow.AddHours(-1), DateTime.UtcNow);

            Assert.NotNull(response);

            Assert.NotNull(response.Result);

            Assert.True(response.Result.Found > 0);
            Assert.True(response.Result.Page == 0);
            Assert.True(response.Result.PerPage == 100);

            Assert.NotNull(response.Result.Items);
            Assert.NotEmpty(response.Result.Items);

            Assert.Equal(HttpStatusCode.OK, response.Code);
        }

        [Fact]
        public async Task GetVacanciesAsync_WhereDateToLessThanDateFromParam_ThrowException()
        {
            var action = async () => { await _httpClient.GetVacanciesAsync(1, 100, DateTime.UtcNow, 
                DateTime.UtcNow.AddMinutes(-1)); 
            };

            await Assert.ThrowsAsync<ArgumentOutOfRangeException>(action);
        }

        [Fact]
        public async Task GetVacancyAsync_WithNegativeIdParam_ThrowException()
        {
            var action = async () => { await _httpClient.GetVacancyAsync(-1); };

            await Assert.ThrowsAsync<ArgumentOutOfRangeException>(action);
        }

        [Fact]
        public async Task GetVacancyAsync_WithZeroIdParam_ThrowException()
        {
            var action = async () => { await _httpClient.GetVacancyAsync(0); };

            await Assert.ThrowsAsync<ArgumentOutOfRangeException>(action);
        }

        [Fact]
        public async Task GetVacancyAsync_WithPositiveExistsIdParam_ReturnOkResponseWithNotNullResult()
        {
            var response = await _httpClient.GetVacancyAsync(68666518);

            Assert.NotNull(response);

            Assert.NotNull(response.Result);

            Assert.Equal(HttpStatusCode.OK, response.Code);
        }

        [Fact]
        public async Task GetVacancyAsync_WithPositiveButNotExistsIdParam_ReturnNotFoundResponseWithNotNullResult()
        {
            var response = await _httpClient.GetVacancyAsync(1);

            Assert.NotNull(response);

            Assert.NotNull(response.Result);

            Assert.Equal(HttpStatusCode.NotFound, response.Code);
        }
    }
}
