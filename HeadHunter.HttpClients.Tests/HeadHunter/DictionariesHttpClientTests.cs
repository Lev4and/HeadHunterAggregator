using System.Net;

namespace HeadHunter.HttpClients.Tests.HeadHunter
{
    public class DictionariesHttpClientTests
    {
        private readonly HttpContext _context;

        public DictionariesHttpClientTests()
        {
            _context = new HttpContext();
        }

        [Fact]
        public async Task GetDictionariesAsync_ReturnSuccessResponseWithNotNullResult()
        {
            var response = await _context.HeadHunter.Dictionaries.GetDictionariesAsync();
            var statusCode = response.Status.Code;

            Assert.NotNull(response);
            Assert.NotNull(response.Result);

            Assert.Equal(HttpStatusCode.OK, statusCode);
        }
    }
}
