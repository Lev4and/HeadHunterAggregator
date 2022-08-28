using System.Net;

namespace HeadHunter.HttpClients.Tests.Resource
{
    public class HeadHunterCountriesHttpClientTests
    {
        private readonly HttpContext _context;

        public HeadHunterCountriesHttpClientTests()
        {
            _context = new HttpContext();
        }

        [Fact]
        public async Task GetAllCountriesAsync_ReturnSuccessResponseWithNotEmptyResult()
        {
            var response = await _context.Resource.HeadHunterCountries.GetAllCountriesAsync();
            var statusCode = response.Status.Code;

            Assert.NotNull(response);
            Assert.NotEmpty(response.Result);

            Assert.Equal(HttpStatusCode.OK, statusCode);
        }
    }
}
