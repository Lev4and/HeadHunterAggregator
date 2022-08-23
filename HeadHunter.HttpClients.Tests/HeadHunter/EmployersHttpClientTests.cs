using System.Net;

namespace HeadHunter.HttpClients.Tests.HeadHunter
{
    public class EmployersHttpClientTests
    {
        private readonly HttpContext _context;

        public EmployersHttpClientTests()
        {
            _context = new HttpContext();
        }

        [Fact]
        public async Task GetEmployerAsync_WithInvalidIdParam_ThrowException()
        {
            var action = async () => { await _context.HeadHunter.Employers.GetEmployerAsync(0); };

            await Assert.ThrowsAsync<ArgumentOutOfRangeException>(action);
        }

        [Fact]
        public async Task GetEmployerAsync_WithNotExistsIdParam_ReturnNotFoundResponseWithNotNullResult()
        {
            var response = await _context.HeadHunter.Employers.GetEmployerAsync(777);
            var statusCode = response.Status.Code;

            Assert.NotNull(response);
            Assert.NotNull(response.Result);

            Assert.Equal(HttpStatusCode.NotFound, statusCode);
        }

        [Fact]
        public async Task GetEmployerAsync_WithValidIdParam_ReturnSuccessResponseWithNotNullResult()
        {
            var response = await _context.HeadHunter.Employers.GetEmployerAsync(2925151);
            var statusCode = response.Status.Code;

            Assert.NotNull(response);
            Assert.NotNull(response.Result);

            Assert.Equal(HttpStatusCode.OK, statusCode);
        }
    }
}
