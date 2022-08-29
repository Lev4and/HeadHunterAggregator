using HeadHunter.HttpClients;
using HeadHunter.Model.Common;
using HeadHunter.Models;
using HeadHunter.ResourceWebApplication.Areas.HeadHunter.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Net;

namespace HeadHunter.ResourceWebApplication.ControllerTests.Areas.HeadHunter.Controllers
{
    public class CompaniesControllerTests
    {
        private readonly Mock<HttpContext> _service;

        public CompaniesControllerTests()
        {
            _service = new Mock<HttpContext>();
        }

        [Fact]
        public async Task GetCompanyByIdAsync_WithInvalidIdParam_ReturnBadRequestResponseWithNullResult()
        {
            var controller = new CompaniesController(_service.Object);

            var response = await controller.GetCompanyByIdAsync(0);
            var result = response as ObjectResult;
            var value = result?.Value as ResponseModel<object?>;

            Assert.Null(value?.Result);
            Assert.Equal(400, result?.StatusCode);
            Assert.Equal(HttpStatusCode.BadRequest, value?.Status?.Code);
        }

        [Fact]
        public async Task GetCompanyByIdAsync_WithNotExistsIdParam_ReturnNotFoundResponseWithNotNullResult()
        {
            var controller = new CompaniesController(_service.Object);

            var response = await controller.GetCompanyByIdAsync(777);
            var result = response as ObjectResult;
            var value = result?.Value as ResponseModel<Employer>;

            Assert.NotNull(value?.Result);
            Assert.Equal(404, result?.StatusCode);
            Assert.Equal(HttpStatusCode.NotFound, value?.Status?.Code);
        }

        [Fact]
        public async Task GetCompanyByIdAsync_WithValidIdParam_ReturnSuccessResponseWithNotNullResult()
        {
            var controller = new CompaniesController(_service.Object);

            var response = await controller.GetCompanyByIdAsync(2925151);
            var result = response as ObjectResult;
            var value = result?.Value as ResponseModel<Employer>;

            Assert.NotNull(value?.Result);
            Assert.Equal(200, result?.StatusCode);
            Assert.Equal(HttpStatusCode.OK, value?.Status?.Code);
        }
    }
}
