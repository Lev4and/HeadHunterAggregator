using HeadHunter.HttpClients;
using HeadHunter.Model.Common;
using HeadHunter.Models;
using HeadHunter.ResourceWebApplication.Areas.HeadHunter.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Net;

namespace HeadHunter.ResourceWebApplication.Tests.Areas.HeadHunter.Controllers
{
    public class MetroControllerTests
    {
        private readonly Mock<HttpContext> _service;

        public MetroControllerTests()
        {
            _service = new Mock<HttpContext>();
        }

        [Fact]
        public async Task GetAllStationsMetroAsync_ReturnSuccessResponseWithNotEmptyResult()
        {
            var controller = new MetroController(_service.Object);

            var response = await controller.GetAllStationsMetroAsync();
            var result = response as ObjectResult;
            var value = result?.Value as ResponseModel<City[]>;

            Assert.NotEmpty(value?.Result);
            Assert.Equal(200, result?.StatusCode);
            Assert.Equal(HttpStatusCode.OK, value?.Status?.Code);
        }

        [Fact]
        public async Task GetAllStationsMetroByCityIdAsync_WithInvalidCityIdParam_ReturnBadRequestResponseWithNullResult()
        {
            var controller = new MetroController(_service.Object);

            var response = await controller.GetAllStationsMetroByCityIdAsync(0);
            var result = response as ObjectResult;
            var value = result?.Value as ResponseModel<object?>;

            Assert.Null(value?.Result);
            Assert.Equal(400, result?.StatusCode);
            Assert.Equal(HttpStatusCode.BadRequest, value?.Status?.Code);
        }

        [Fact]
        public async Task GetAllStationsMetroByCityIdAsync_WithNotExistsCityIdParam_ReturnNotFoundResponseWithNotNullResult()
        {
            var controller = new MetroController(_service.Object);

            var response = await controller.GetAllStationsMetroByCityIdAsync(777);
            var result = response as ObjectResult;
            var value = result?.Value as ResponseModel<City>;

            Assert.NotNull(value?.Result);
            Assert.Equal(404, result?.StatusCode);
            Assert.Equal(HttpStatusCode.NotFound, value?.Status?.Code);
        }

        [Fact]
        public async Task GetAllStationsMetroByCityIdAsync_WithValidCityIdParam_ReturnSuccessResponseWithNotNullResult()
        {
            var controller = new MetroController(_service.Object);

            var response = await controller.GetAllStationsMetroByCityIdAsync(1);
            var result = response as ObjectResult;
            var value = result?.Value as ResponseModel<City>;

            Assert.NotNull(value?.Result);
            Assert.Equal(200, result?.StatusCode);
            Assert.Equal(HttpStatusCode.OK, value?.Status?.Code);
        }
    }
}
