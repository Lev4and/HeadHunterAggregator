using HeadHunter.HttpClients;
using HeadHunter.HttpClients.HeadHunter.ResponseModels;
using HeadHunter.Model.Common;
using HeadHunter.Models;
using HeadHunter.ResourceWebApplication.Areas.HeadHunter.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Net;

namespace HeadHunter.ResourceWebApplication.ControllerTests.Areas.HeadHunter.Controllers
{
    public class UniversitiesControllerTests
    {
        private readonly Mock<HttpContext> _service;

        public UniversitiesControllerTests()
        {
            _service = new Mock<HttpContext>();
        }

        [Fact]
        public async Task GetUniversityByIdAsync_WithInvalidIdParam_ReturnBadRequestResponseWithNullResult()
        {
            var controller = new UniversitiesController(_service.Object);

            var response = await controller.GetUniversityByIdAsync(0);
            var result = response as ObjectResult;
            var value = result?.Value as ResponseModel<object?>;

            Assert.Null(value?.Result);
            Assert.Equal(400, result?.StatusCode);
            Assert.Equal(HttpStatusCode.BadRequest, value?.Status?.Code);
        }

        [Fact]
        public async Task GetUniversityByIdAsync_WithNotExistsIdParam_ReturnSuccessResponseWithEmptyResult()
        {
            var controller = new UniversitiesController(_service.Object);

            var response = await controller.GetUniversityByIdAsync(1);
            var result = response as ObjectResult;
            var value = result?.Value as ResponseModel<ItemsResponseModel<University>>;

            Assert.Empty(value?.Result.Items);
            Assert.Equal(200, result?.StatusCode);
            Assert.Equal(HttpStatusCode.OK, value?.Status?.Code);
        }

        [Fact]
        public async Task GetUniversityByIdAsync_WithValidIdParam_ReturnSuccessResponseWithNotEmptyResult()
        {
            var controller = new UniversitiesController(_service.Object);

            var response = await controller.GetUniversityByIdAsync(45470);
            var result = response as ObjectResult;
            var value = result?.Value as ResponseModel<ItemsResponseModel<University>>;

            Assert.NotEmpty(value?.Result.Items);
            Assert.Equal(200, result?.StatusCode);
            Assert.Equal(HttpStatusCode.OK, value?.Status?.Code);
        }

        [Fact]
        public async Task GetUniversitiesByIdsAsync_WithNullIdsParam_ReturnBadRequestResponseWithNullResult()
        {
            var controller = new UniversitiesController(_service.Object);

            var response = await controller.GetUniversitiesByIdsAsync(null);
            var result = response as ObjectResult;
            var value = result?.Value as ResponseModel<object?>;

            Assert.Null(value?.Result);
            Assert.Equal(400, result?.StatusCode);
            Assert.Equal(HttpStatusCode.BadRequest, value?.Status?.Code);
        }

        [Fact]
        public async Task GetUniversitiesByIdsAsync_WithEmptyIdsParam_ReturnBadRequestResponseWithNullResult()
        {
            var controller = new UniversitiesController(_service.Object);

            var response = await controller.GetUniversitiesByIdsAsync(new int[0]);
            var result = response as ObjectResult;
            var value = result?.Value as ResponseModel<object?>;

            Assert.Null(value?.Result);
            Assert.Equal(400, result?.StatusCode);
            Assert.Equal(HttpStatusCode.BadRequest, value?.Status?.Code);
        }

        [Fact]
        public async Task GetUniversitiesByIdsAsync_WhenSomeItemOfIdsParamNotValid_ReturnBadRequestResponseWithNullResult()
        {
            var controller = new UniversitiesController(_service.Object);

            var response = await controller.GetUniversitiesByIdsAsync(new int[3] { 0, 1, 2 });
            var result = response as ObjectResult;
            var value = result?.Value as ResponseModel<object?>;

            Assert.Null(value?.Result);
            Assert.Equal(400, result?.StatusCode);
            Assert.Equal(HttpStatusCode.BadRequest, value?.Status?.Code);
        }

        [Fact]
        public async Task GetUniversitiesByIdsAsync_WhenAllItemsOfIdsParamValid_ReturnSuccessResponseWithEmptyResult()
        {
            var controller = new UniversitiesController(_service.Object);

            var response = await controller.GetUniversitiesByIdsAsync(new int[2] { 45470, 39196 });
            var result = response as ObjectResult;
            var value = result?.Value as ResponseModel<ItemsResponseModel<University>>;

            Assert.NotEmpty(value?.Result?.Items);
            Assert.Equal(2, value?.Result?.Items?.Length);
            Assert.Equal(200, result?.StatusCode);
            Assert.Equal(HttpStatusCode.OK, value?.Status?.Code);
        }

        [Fact]
        public async Task GetUniversitiesByIdsAsync_WhenSomeItemOfIdsParamNotExists_ReturnSuccessResponseWithEmptyResult()
        {
            var controller = new UniversitiesController(_service.Object);

            var response = await controller.GetUniversitiesByIdsAsync(new int[3] { 1, 2, 39196 });
            var result = response as ObjectResult;
            var value = result?.Value as ResponseModel<ItemsResponseModel<University>>;

            Assert.NotEmpty(value?.Result?.Items);
            Assert.Equal(1, value?.Result?.Items?.Length);
            Assert.Equal(200, result?.StatusCode);
            Assert.Equal(HttpStatusCode.OK, value?.Status?.Code);
        }
    }
}
