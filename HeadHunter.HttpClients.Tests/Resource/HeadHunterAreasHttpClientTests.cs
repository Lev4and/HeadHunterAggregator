using System.Net;

namespace HeadHunter.HttpClients.Tests.Resource
{
    public class HeadHunterAreasHttpClientTests
    {
        private readonly HttpContext _context;

        public HeadHunterAreasHttpClientTests()
        {
            _context = new HttpContext();
        }

        [Fact]
        public async Task GetAllAsync_ReturnSuccessResponseWithNotEmptyResult()
        {
            var response = await _context.Resource.HeadHunterAreas.GetAllAsync();
            var statusCode = response.Status.Code;

            Assert.NotNull(response);
            Assert.NotEmpty(response.Result);

            Assert.Equal(HttpStatusCode.OK, statusCode);
        }

        [Fact]
        public async Task GetAreaAsync_WithInvalidIdParam_ThrowException()
        {
            var action = async () => { await _context.Resource.HeadHunterAreas.GetAreaAsync(0); };

            await Assert.ThrowsAsync<ArgumentOutOfRangeException>(action);
        }

        [Fact]
        public async Task GetAreaAsync_WithValidIdParam_ReturnSuccessResponseWithNotNullResult()
        {
            var response = await _context.Resource.HeadHunterAreas.GetAreaAsync(1);
            var statusCode = response.Status.Code;

            Assert.NotNull(response);
            Assert.NotNull(response.Result);

            Assert.Equal(HttpStatusCode.OK, statusCode);
        }

        [Fact]
        public async Task GetAreaAsync_WithNotExistsValidIdParam_ReturnNotFoundResponseWithNotNullResult()
        {
            var response = await _context.Resource.HeadHunterAreas.GetAreaAsync(777);
            var statusCode = response.Status.Code;

            Assert.NotNull(response);
            Assert.NotNull(response.Result);

            Assert.Equal(HttpStatusCode.NotFound, statusCode);
        }
    }
}
