using System.Net;

namespace HeadHunter.HttpClients.Tests.HeadHunter
{
    public class LanguagesHttpClientTests
    {
        private readonly HttpContext _context;

        public LanguagesHttpClientTests()
        {
            _context = new HttpContext();
        }

        [Fact]
        public async Task GetLanguagesAsync_ReturnSuccessResponseWithNotNullResult()
        {
            var response = await _context.HeadHunter.Languages.GetLanguagesAsync();
            var statusCode = response.Status.Code;

            Assert.NotNull(response);
            Assert.NotNull(response.Result);

            Assert.Equal(HttpStatusCode.OK, statusCode);
        }
    }
}
