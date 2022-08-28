using HeadHunter.HttpClients.HeadHunter;
using System.Net;

namespace HeadHunter.HttpClients.Tests.HeadHunter
{
    public class AreasHttpClientTests
    {
        private readonly HttpContext _context;

        public AreasHttpClientTests()
        {
            _context = new HttpContext();
        }

        [Fact]
        public async Task GetAllCountriesAsync_ReturnSuccessResponseWithNotEmptyResult()
        {
            var response = await _context.HeadHunter.Areas.GetAllCountriesAsync();
            var statusCode = response.Status.Code;

            Assert.NotNull(response);
            Assert.NotEmpty(response.Result);

            Assert.Equal(HttpStatusCode.OK, statusCode);
        }

        [Fact]
        public async Task GetAllAreasAsync_ReturnSuccessResponseWithNotEmptyResult()
        {
            var response = await _context.HeadHunter.Areas.GetAllAreasAsync();
            var statusCode = response.Status.Code;

            Assert.NotNull(response);
            Assert.NotEmpty(response.Result);

            Assert.Equal(HttpStatusCode.OK, statusCode);
        }

        [Fact]
        public async Task GetAreaAsync_WithInvalidIdParam_ThrowException()
        {
            var action = async () => { await _context.HeadHunter.Areas.GetAreaAsync(HeadHunterConstants.IdLowerValue - 1); };

            await Assert.ThrowsAsync<ArgumentOutOfRangeException>(action);
        }

        [Fact]
        public async Task GetAreaAsync_WithValidIdParam_ReturnSuccessResponseWithNotNullResult()
        {
            var response = await _context.HeadHunter.Areas.GetAreaAsync(HeadHunterConstants.IdLowerValue);
            var statusCode = response.Status.Code;

            Assert.NotNull(response);
            Assert.NotNull(response.Result);

            Assert.Equal(HttpStatusCode.OK, statusCode);
        }

        [Fact]
        public async Task GetAreaAsync_WithNotExistsValidIdParam_ReturnNotFoundResponseWithNotNullResult()
        {
            var response = await _context.HeadHunter.Areas.GetAreaAsync(777);
            var statusCode = response.Status.Code;

            Assert.NotNull(response);
            Assert.NotNull(response.Result);

            Assert.Equal(HttpStatusCode.NotFound, statusCode);
        }
    }
}
