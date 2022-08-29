using HeadHunter.HttpClients;
using HeadHunter.Model.Common;
using HeadHunter.Models;
using HeadHunter.ResourceWebApplication.Areas.HeadHunter.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Net;

namespace HeadHunter.ResourceWebApplication.ControllerTests.Areas.HeadHunter.Controllers
{
    public class AreasControllerTests
    {
        private readonly Mock<HttpContext> _service;

        public AreasControllerTests()
        {
            _service = new Mock<HttpContext>();
        }

        [Fact]
        public async Task GetAllAreasAsync_ReturnSuccessResponseWithNotEmptyResult()
        {
            var controller = new AreasController(_service.Object);

            var response = await controller.GetAllAreasAsync();
            var result = response as ObjectResult;
            var value = result?.Value as ResponseModel<Area[]>;

            Assert.NotEmpty(value?.Result);
            Assert.Equal(200, result?.StatusCode);
            Assert.Equal(HttpStatusCode.OK, value?.Status?.Code);
        }

        [Fact]
        public async Task GetAreaByIdAsync_WithInvalidIdParam_ReturnBadRequestResponseWithNullResult()
        {
            var controller = new AreasController(_service.Object);

            var response = await controller.GetAreaByIdAsync(0);
            var result = response as ObjectResult;
            var value = result?.Value as ResponseModel<object?>;

            Assert.Null(value?.Result);
            Assert.Equal(400, result?.StatusCode);
            Assert.Equal(HttpStatusCode.BadRequest, value?.Status?.Code);
        }

        [Fact]
        public async Task GetAreaByIdAsync_WithNotExistsIdParam_ReturnNotFoundResponseWithNotNullResult()
        {
            var controller = new AreasController(_service.Object);

            var response = await controller.GetAreaByIdAsync(777);
            var result = response as ObjectResult;
            var value = result?.Value as ResponseModel<Area>;

            Assert.NotNull(value?.Result);
            Assert.Equal(404, result?.StatusCode);
            Assert.Equal(HttpStatusCode.NotFound, value?.Status?.Code);
        }

        [Fact]
        public async Task GetAreaByIdAsync_WithValidIdParam_ReturnSuccessResponseWithNotNullResult()
        {
            var controller = new AreasController(_service.Object);

            var response = await controller.GetAreaByIdAsync(1);
            var result = response as ObjectResult;
            var value = result?.Value as ResponseModel<Area>;

            Assert.NotNull(value?.Result);
            Assert.Equal(200, result?.StatusCode);
            Assert.Equal(HttpStatusCode.OK, value?.Status?.Code);
        }
    }
}
