using System.Net;

namespace HeadHunter.HttpClients.Tests.Resource
{
    public class HeadHunterSpecializationsHttpClientTests
    {
        private readonly HttpContext _context;

        public HeadHunterSpecializationsHttpClientTests()
        {
            _context = new HttpContext();
        }

        [Fact]
        public async Task GetAllAsync_ReturnSuccessResponseWithNotEmptyResult()
        {
            var response = await _context.Resource.HeadHunterSpecializations.GetAllAsync();
            var statusCode = response.Status.Code;

            Assert.NotNull(response);
            Assert.NotEmpty(response.Result);

            Assert.Equal(HttpStatusCode.OK, statusCode);
        }
    }
}
