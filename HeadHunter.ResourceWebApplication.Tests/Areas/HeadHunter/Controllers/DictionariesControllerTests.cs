using HeadHunter.HttpClients;
using HeadHunter.Model.Common;
using HeadHunter.Models;
using HeadHunter.ResourceWebApplication.Areas.HeadHunter.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Net;

namespace HeadHunter.ResourceWebApplication.Tests.Areas.HeadHunter.Controllers
{
    public class DictionariesControllerTests
    {
        private readonly Mock<HttpContext> _service;

        public DictionariesControllerTests()
        {
            _service = new Mock<HttpContext>();
        }

        [Fact]
        public async Task GetDictionariesAsync_ReturnSuccessResponseWithNotNullResult()
        {
            var controller = new DictionariesController(_service.Object);

            var response = await controller.GetDictionariesAsync();
            var result = response as ObjectResult;
            var value = result?.Value as ResponseModel<Dictionaries>;

            Assert.NotNull(value?.Result);
            Assert.Equal(200, result?.StatusCode);
            Assert.Equal(HttpStatusCode.OK, value?.Status?.Code);
        }
    }
}
