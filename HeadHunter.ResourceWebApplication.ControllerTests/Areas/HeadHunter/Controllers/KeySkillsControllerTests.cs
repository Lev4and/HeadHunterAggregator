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
    public class KeySkillsControllerTests
    {
        private readonly Mock<HttpContext> _service;

        public KeySkillsControllerTests()
        {
            _service = new Mock<HttpContext>();
        }

        [Fact]
        public async Task GetKeySkillByIdAsync_WithInvalidIdParam_ReturnBadRequestResponseWithNullResult()
        {
            var controller = new KeySkillsController(_service.Object);

            var response = await controller.GetKeySkillByIdAsync(0);
            var result = response as ObjectResult;
            var value = result?.Value as ResponseModel<object?>;

            Assert.Null(value?.Result);
            Assert.Equal(400, result?.StatusCode);
            Assert.Equal(HttpStatusCode.BadRequest, value?.Status?.Code);
        }

        [Fact]
        public async Task GetKeySkillByIdAsync_WithNotExistsIdParam_ReturnSuccessResponseWithEmptyResult()
        {
            var controller = new KeySkillsController(_service.Object);

            var response = await controller.GetKeySkillByIdAsync(123456789);
            var result = response as ObjectResult;
            var value = result?.Value as ResponseModel<ItemsResponseModel<KeySkill>>;

            Assert.Empty(value?.Result.Items);
            Assert.Equal(200, result?.StatusCode);
            Assert.Equal(HttpStatusCode.OK, value?.Status?.Code);
        }

        [Fact]
        public async Task GetKeySkillByIdAsync_WithValidIdParam_ReturnSuccessResponseWithNotEmptyResult()
        {
            var controller = new KeySkillsController(_service.Object);

            var response = await controller.GetKeySkillByIdAsync(1);
            var result = response as ObjectResult;
            var value = result?.Value as ResponseModel<ItemsResponseModel<KeySkill>>;

            Assert.NotEmpty(value?.Result.Items);
            Assert.Equal(200, result?.StatusCode);
            Assert.Equal(HttpStatusCode.OK, value?.Status?.Code);
        }

        [Fact]
        public async Task GetKeySkillsByIdsAsync_WithNullIdsParam_ReturnBadRequestResponseWithNullResult()
        {
            var controller = new KeySkillsController(_service.Object);

            var response = await controller.GetKeySkillsByIdsAsync(null);
            var result = response as ObjectResult;
            var value = result?.Value as ResponseModel<object?>;

            Assert.Null(value?.Result);
            Assert.Equal(400, result?.StatusCode);
            Assert.Equal(HttpStatusCode.BadRequest, value?.Status?.Code);
        }

        [Fact]
        public async Task GetKeySkillsByIdsAsync_WithEmptyIdsParam_ReturnBadRequestResponseWithNullResult()
        {
            var controller = new KeySkillsController(_service.Object);

            var response = await controller.GetKeySkillsByIdsAsync(new int[0]);
            var result = response as ObjectResult;
            var value = result?.Value as ResponseModel<object?>;

            Assert.Null(value?.Result);
            Assert.Equal(400, result?.StatusCode);
            Assert.Equal(HttpStatusCode.BadRequest, value?.Status?.Code);
        }

        [Fact]
        public async Task GetKeySkillsByIdsAsync_WhenSomeItemOfIdsParamNotValid_ReturnBadRequestResponseWithNullResult()
        {
            var controller = new KeySkillsController(_service.Object);

            var response = await controller.GetKeySkillsByIdsAsync(new int[3] { 0, 1, 2 });
            var result = response as ObjectResult;
            var value = result?.Value as ResponseModel<object?>;

            Assert.Null(value?.Result);
            Assert.Equal(400, result?.StatusCode);
            Assert.Equal(HttpStatusCode.BadRequest, value?.Status?.Code);
        }

        [Fact]
        public async Task GetKeySkillsByIdsAsync_WhenAllItemsOfIdsParamValid_ReturnSuccessResponseWithEmptyResult()
        {
            var controller = new KeySkillsController(_service.Object);

            var response = await controller.GetKeySkillsByIdsAsync(new int[3] { 1, 2, 3 });
            var result = response as ObjectResult;
            var value = result?.Value as ResponseModel<ItemsResponseModel<KeySkill>>;

            Assert.NotEmpty(value?.Result?.Items);
            Assert.Equal(3, value?.Result?.Items?.Length);
            Assert.Equal(200, result?.StatusCode);
            Assert.Equal(HttpStatusCode.OK, value?.Status?.Code);
        }

        [Fact]
        public async Task GetKeySkillsByIdsAsync_WhenSomeItemOfIdsParamNotExists_ReturnSuccessResponseWithEmptyResult()
        {
            var controller = new KeySkillsController(_service.Object);

            var response = await controller.GetKeySkillsByIdsAsync(new int[3] { 1, 2, 123456789 });
            var result = response as ObjectResult;
            var value = result?.Value as ResponseModel<ItemsResponseModel<KeySkill>>;

            Assert.NotEmpty(value?.Result?.Items);
            Assert.Equal(2, value?.Result?.Items?.Length);
            Assert.Equal(200, result?.StatusCode);
            Assert.Equal(HttpStatusCode.OK, value?.Status?.Code);
        }
    }
}
