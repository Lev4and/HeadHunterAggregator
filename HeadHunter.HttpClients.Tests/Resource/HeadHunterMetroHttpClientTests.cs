using System.Net;

namespace HeadHunter.HttpClients.Tests.Resource
{
    public class HeadHunterMetroHttpClientTests
    {
        private readonly HttpContext _context;

        public HeadHunterMetroHttpClientTests()
        {
            _context = new HttpContext();
        }

        [Fact]
        public async Task GetAllAsync_ReturnSuccessResponseWithNotNullResult()
        {
            var response = await _context.Resource.HeadHunterMetro.GetAllAsync();
            var statusCode = response.Status.Code;

            Assert.NotNull(response);
            Assert.NotNull(response.Result);

            Assert.Equal(HttpStatusCode.OK, statusCode);
        }

        [Fact]
        public async Task GetAllStationsMetroByCityIdAsync_WithInvalidCityIdParam_ThrowException()
        {
            var action = async () => { await _context.Resource.HeadHunterMetro.GetAllStationsMetroByCityIdAsync(-1); };

            await Assert.ThrowsAsync<ArgumentOutOfRangeException>(action);
        }

        [Fact]
        public async Task GetAllStationsMetroByCityIdAsync_WithValidCityIdParam_ReturnSuccessResponseWithNotNullResult()
        {
            var response = await _context.Resource.HeadHunterMetro.GetAllStationsMetroByCityIdAsync(1);
            var statusCode = response.Status.Code;

            Assert.NotNull(response);
            Assert.NotNull(response.Result);
            Assert.Equal(HttpStatusCode.OK, statusCode);
        }

        [Fact]
        public async Task GetAllStationsMetroByCityIdAsync_WithNotExistsCityIdParam_ReturnNotFoundResponseWithNotNullResult()
        {
            var response = await _context.Resource.HeadHunterMetro.GetAllStationsMetroByCityIdAsync(777);
            var statusCode = response.Status.Code;

            Assert.NotNull(response);
            Assert.NotNull(response.Result);
            Assert.Equal(HttpStatusCode.NotFound, statusCode);
        }
    }
}
