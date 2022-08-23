using System.Net;

namespace HeadHunter.HttpClients.Tests.HeadHunter
{
    public class IndustriesHttpClientTests
    {
        private readonly HttpContext _context;

        public IndustriesHttpClientTests()
        {
            _context = new HttpContext();
        }

        [Fact]
        public async Task GetIndustriesAsync_ReturnSuccessResponseWithNotNullResult()
        {
            var response = await _context.HeadHunter.Industries.GetIndustriesAsync();
            var statusCode = response.Status.Code;

            Assert.NotNull(response);
            Assert.NotNull(response.Result);

            Assert.Equal(HttpStatusCode.OK, statusCode);
        }
    }
}
