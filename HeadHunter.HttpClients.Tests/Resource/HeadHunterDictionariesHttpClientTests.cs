using System.Net;

namespace HeadHunter.HttpClients.Tests.Resource
{
    public class HeadHunterDictionariesHttpClientTests
    {
        private readonly HttpContext _context;

        public HeadHunterDictionariesHttpClientTests()
        {
            _context = new HttpContext();
        }

        [Fact]
        public async Task GetDictionariesAsync_ReturnSuccessResponseWithNotNullResult()
        {
            var response = await _context.Resource.HeadHunterDictionaries.GetDictionariesAsync();
            var statusCode = response.Status.Code;

            Assert.NotNull(response);
            Assert.NotNull(response.Result);

            Assert.Equal(HttpStatusCode.OK, statusCode);
        }
    }
}
