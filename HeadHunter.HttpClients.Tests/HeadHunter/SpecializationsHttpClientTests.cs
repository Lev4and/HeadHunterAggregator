using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace HeadHunter.HttpClients.Tests.HeadHunter
{
    public class SpecializationsHttpClientTests
    {
        private readonly HttpContext _context;

        public SpecializationsHttpClientTests()
        {
            _context = new HttpContext();
        }

        [Fact]
        public async Task GetAllSpecializationsAsync_ReturnSuccessResponseWithNotEmptyResult()
        {
            var response = await _context.HeadHunter.Specializations.GetAllSpecializationsAsync();
            var statusCode = response.Status.Code;

            Assert.NotNull(response);
            Assert.NotEmpty(response.Result);

            Assert.Equal(HttpStatusCode.OK, statusCode);
        }
    }
}
