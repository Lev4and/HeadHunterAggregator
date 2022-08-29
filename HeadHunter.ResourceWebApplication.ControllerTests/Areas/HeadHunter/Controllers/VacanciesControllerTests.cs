using HeadHunter.HttpClients;
using HeadHunter.HttpClients.HeadHunter;
using HeadHunter.HttpClients.HeadHunter.ResponseModels;
using HeadHunter.Model.Common;
using HeadHunter.Models;
using HeadHunter.ResourceWebApplication.Areas.HeadHunter.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Net;

namespace HeadHunter.ResourceWebApplication.ControllerTests.Areas.HeadHunter.Controllers
{
    public class VacanciesControllerTests
    {
        private readonly Mock<HttpContext> _service;

        public VacanciesControllerTests()
        {
            _service = new Mock<HttpContext>();
        }

        [Fact]
        public async Task GetVacanciesAsync_WithPerPageParamLessThanPerPageLowerValue_ReturnBadRequestResponseWithNullResult()
        {
            var controller = new VacanciesController(_service.Object);

            var response = await controller.GetVacanciesAsync(100, HeadHunterConstants.PerPageLowerValue - 1, DateTime.UtcNow, DateTime.UtcNow);
            var result = response as ObjectResult;
            var value = result?.Value as ResponseModel<object?>;

            Assert.Null(value?.Result);
            Assert.Equal(400, result?.StatusCode);
            Assert.Equal(HttpStatusCode.BadRequest, value?.Status?.Code);
        }

        [Fact]
        public async Task GetVacanciesAsync_WithPerPageParamGreaterThanPerPageUpperValue_ReturnBadRequestResponseWithNullResult()
        {
            var controller = new VacanciesController(_service.Object);

            var response = await controller.GetVacanciesAsync(100, HeadHunterConstants.PerPageUpperValue + 1, DateTime.UtcNow, DateTime.UtcNow);
            var result = response as ObjectResult;
            var value = result?.Value as ResponseModel<object?>;

            Assert.Null(value?.Result);
            Assert.Equal(400, result?.StatusCode);
            Assert.Equal(HttpStatusCode.BadRequest, value?.Status?.Code);
        }

        [Fact]
        public async Task GetVacanciesAsync_WithPageParamLessThanPageLowerValue_ReturnBadRequestResponseWithNullResult()
        {
            var controller = new VacanciesController(_service.Object);

            var response = await controller.GetVacanciesAsync(HeadHunterConstants.PageLowerValue - 1, HeadHunterConstants.PerPageUpperValue, DateTime.UtcNow, DateTime.UtcNow);
            var result = response as ObjectResult;
            var value = result?.Value as ResponseModel<object?>;

            Assert.Null(value?.Result);
            Assert.Equal(400, result?.StatusCode);
            Assert.Equal(HttpStatusCode.BadRequest, value?.Status?.Code);
        }

        [Fact]
        public async Task GetVacanciesAsync_WhenOffsetExceedsThanOffsetUpperValue_ReturnBadRequestResponseWithNullResult()
        {
            var controller = new VacanciesController(_service.Object);

            var response = await controller.GetVacanciesAsync(20, 100, DateTime.UtcNow, DateTime.UtcNow);
            var result = response as ObjectResult;
            var value = result?.Value as ResponseModel<object?>;

            Assert.Null(value?.Result);
            Assert.Equal(400, result?.StatusCode);
            Assert.Equal(HttpStatusCode.BadRequest, value?.Status?.Code);
        }

        [Fact]
        public async Task GetVacanciesAsync_WhenDateFromParamGreaterThanDateToParam_ReturnBadRequestResponseWithNullResult()
        {
            var controller = new VacanciesController(_service.Object);

            var response = await controller.GetVacanciesAsync(20, 100, DateTime.UtcNow.AddHours(1), DateTime.UtcNow);
            var result = response as ObjectResult;
            var value = result?.Value as ResponseModel<object?>;

            Assert.Null(value?.Result);
            Assert.Equal(400, result?.StatusCode);
            Assert.Equal(HttpStatusCode.BadRequest, value?.Status?.Code);
        }

        [Fact]
        public async Task GetVacanciesAsync_WhenDateToParamLessThanDateFromParam_ReturnBadRequestResponseWithNullResult()
        {
            var controller = new VacanciesController(_service.Object);

            var response = await controller.GetVacanciesAsync(20, 100, DateTime.UtcNow, DateTime.UtcNow.AddHours(-1));
            var result = response as ObjectResult;
            var value = result?.Value as ResponseModel<object?>;

            Assert.Null(value?.Result);
            Assert.Equal(400, result?.StatusCode);
            Assert.Equal(HttpStatusCode.BadRequest, value?.Status?.Code);
        }

        [Fact]
        public async Task GetVacanciesAsync_WhenValidParams_ReturnSuccessResponseWithNotEmptyResult()
        {
            var controller = new VacanciesController(_service.Object);

            var response = await controller.GetVacanciesAsync(1, 100, DateTime.UtcNow.AddHours(-1), DateTime.UtcNow);
            var result = response as ObjectResult;
            var value = result?.Value as ResponseModel<PagedResponseModel<Vacancy>>;

            Assert.NotNull(value?.Result);
            Assert.Equal(1, value?.Result?.Page);
            Assert.Equal(100, value?.Result?.PerPage);
            Assert.True(value?.Result?.Found > 0);
            Assert.NotEmpty(value?.Result?.Items);
            Assert.Equal(200, result?.StatusCode);
            Assert.Equal(HttpStatusCode.OK, value?.Status?.Code);
        }

        [Fact]
        public async Task GetVacancyByIdAsync_WithInvalidIdParam_ReturnBadRequestResponseWithNullResult()
        {
            var controller = new VacanciesController(_service.Object);

            var response = await controller.GetVacancyByIdAsync(0);
            var result = response as ObjectResult;
            var value = result?.Value as ResponseModel<object?>;

            Assert.Null(value?.Result);
            Assert.Equal(400, result?.StatusCode);
            Assert.Equal(HttpStatusCode.BadRequest, value?.Status?.Code);
        }

        [Fact]
        public async Task GetVacancyByIdAsync_WithNotExistsIdParam_ReturnNotFoundResponseWithNotNullResult()
        {
            var controller = new VacanciesController(_service.Object);

            var response = await controller.GetVacancyByIdAsync(1);
            var result = response as ObjectResult;
            var value = result?.Value as ResponseModel<Vacancy>;

            Assert.NotNull(value?.Result);
            Assert.Equal(404, result?.StatusCode);
            Assert.Equal(HttpStatusCode.NotFound, value?.Status?.Code);
        }

        [Fact]
        public async Task GetVacancyByIdAsync_WithValidIdParam_ReturnSuccessResponseWithNotNullResult()
        {
            var controller = new VacanciesController(_service.Object);

            var response = await controller.GetVacancyByIdAsync(68666518);
            var result = response as ObjectResult;
            var value = result?.Value as ResponseModel<Vacancy>;

            Assert.NotNull(value?.Result);
            Assert.Equal(200, result?.StatusCode);
            Assert.Equal(HttpStatusCode.OK, value?.Status?.Code);
        }
    }
}
