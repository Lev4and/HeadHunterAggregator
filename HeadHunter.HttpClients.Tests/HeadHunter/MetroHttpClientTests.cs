using HeadHunter.HttpClients.HeadHunter;
using System.Net;

namespace HeadHunter.HttpClients.Tests.HeadHunter
{
    public class MetroHttpClientTests
    {
        private readonly HttpContext _context;

        public MetroHttpClientTests()
        {
            _context = new HttpContext();
        }

        [Fact]
        public async Task GetAllStationsMetroAsync_ReturnSuccessResponseWithNotNullResult()
        {
            var response = await _context.HeadHunter.Metro.GetAllStationsMetroAsync();
            var statusCode = response.Status.Code;

            Assert.NotNull(response);
            Assert.NotNull(response.Result);

            Assert.Equal(HttpStatusCode.OK, statusCode);
        }

        [Fact]
        public async Task GetAllStationsMetroByCityIdAsync_WithInvalidCityIdParam_ThrowException()
        {
            var action = async () => { await _context.HeadHunter.Metro.GetAllStationsMetroByCityIdAsync(HeadHunterConstants.IdLowerValue - 1); };

            await Assert.ThrowsAsync<ArgumentOutOfRangeException>(action);
        }

        [Fact]
        public async Task GetAllStationsMetroByCityIdAsync_WithValidCityIdParam_ReturnSuccessResponseWithNotNullResult()
        {
            var response = await _context.HeadHunter.Metro.GetAllStationsMetroByCityIdAsync(HeadHunterConstants.IdLowerValue);
            var statusCode = response.Status.Code;

            Assert.NotNull(response);
            Assert.NotNull(response.Result);
            Assert.Equal(HttpStatusCode.OK, statusCode);
        }

        [Fact]
        public async Task GetAllStationsMetroByCityIdAsync_WithNotExistsCityIdParam_ReturnNotFoundResponseWithNotNullResult()
        {
            var response = await _context.HeadHunter.Metro.GetAllStationsMetroByCityIdAsync(777);
            var statusCode = response.Status.Code;

            Assert.NotNull(response);
            Assert.NotNull(response.Result);
            Assert.Equal(HttpStatusCode.NotFound, statusCode);
        }
    }
}
