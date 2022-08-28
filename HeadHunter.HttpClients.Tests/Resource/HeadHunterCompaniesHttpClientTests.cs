using System.Net;

namespace HeadHunter.HttpClients.Tests.Resource
{
    public class HeadHunterCompaniesHttpClientTests
    {
        private readonly HttpContext _context;

        public HeadHunterCompaniesHttpClientTests()
        {
            _context = new HttpContext();
        }

        [Fact]
        public async Task GetCompanyAsync_WithInvalidIdParam_ThrowException()
        {
            var action = async () => { await _context.Resource.HeadHunterCompanies.GetCompanyAsync(0); };

            await Assert.ThrowsAsync<ArgumentOutOfRangeException>(action);
        }

        [Fact]
        public async Task GetCompanyAsync_WithNotExistsIdParam_ReturnNotFoundResponseWithNotNullResult()
        {
            var response = await _context.Resource.HeadHunterCompanies.GetCompanyAsync(777);
            var statusCode = response.Status.Code;

            Assert.NotNull(response);
            Assert.NotNull(response.Result);

            Assert.Equal(HttpStatusCode.NotFound, statusCode);
        }

        [Fact]
        public async Task GetCompanyAsync_WithValidIdParam_ReturnSuccessResponseWithNotNullResult()
        {
            var response = await _context.Resource.HeadHunterCompanies.GetCompanyAsync(2925151);
            var statusCode = response.Status.Code;

            Assert.NotNull(response);
            Assert.NotNull(response.Result);

            Assert.Equal(HttpStatusCode.OK, statusCode);
        }
    }
}
