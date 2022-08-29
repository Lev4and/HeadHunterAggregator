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
    public class SuggestsControllerTests
    {
        private readonly Mock<HttpContext> _service;

        public SuggestsControllerTests()
        {
            _service = new Mock<HttpContext>();
        }

        [Fact]
        public async Task GetSuggestsAreaLeavesAsync_WithNullSearchStringParam_ReturnBadRequestResponseWithNullResult()
        {
            var controller = new SuggestsController(_service.Object);

            var response = await controller.GetSuggestsAreaLeavesAsync(null);
            var result = response as ObjectResult;
            var value = result?.Value as ResponseModel<object?>;

            Assert.Null(value?.Result);
            Assert.Equal(400, result?.StatusCode);
            Assert.Equal(HttpStatusCode.BadRequest, value?.Status?.Code);
        }

        [Fact]
        public async Task GetSuggestsAreaLeavesAsync_WithEmptySearchStringParam_ReturnBadRequestResponseWithNullResult()
        {
            var controller = new SuggestsController(_service.Object);

            var response = await controller.GetSuggestsAreaLeavesAsync("");
            var result = response as ObjectResult;
            var value = result?.Value as ResponseModel<object?>;

            Assert.Null(value?.Result);
            Assert.Equal(400, result?.StatusCode);
            Assert.Equal(HttpStatusCode.BadRequest, value?.Status?.Code);
        }

        [Fact]
        public async Task GetSuggestsAreaLeavesAsync_WhenSearchStringParamHaveLengthLessThanMinLengthSearchString_ReturnBadRequestResponseWithNullResult()
        {
            var controller = new SuggestsController(_service.Object);

            var response = await controller.GetSuggestsAreaLeavesAsync("Мо");
            var result = response as ObjectResult;
            var value = result?.Value as ResponseModel<object?>;

            Assert.Null(value?.Result);
            Assert.Equal(400, result?.StatusCode);
            Assert.Equal(HttpStatusCode.BadRequest, value?.Status?.Code);
        }

        [Fact]
        public async Task GetSuggestsAreaLeavesAsync_WithValidSearchStringParam_ReturnSuccessResponseWithNotEmptyResult()
        {
            var controller = new SuggestsController(_service.Object);

            var response = await controller.GetSuggestsAreaLeavesAsync("Моск");
            var result = response as ObjectResult;
            var value = result?.Value as ResponseModel<ItemsResponseModel<Area>>;

            Assert.NotEmpty(value?.Result?.Items);
            Assert.Equal(200, result?.StatusCode);
            Assert.Equal(HttpStatusCode.OK, value?.Status?.Code);
        }

        [Fact]
        public async Task GetSuggestsCompaniesLeavesAsync_WithNullSearchStringParam_ReturnBadRequestResponseWithNullResult()
        {
            var controller = new SuggestsController(_service.Object);

            var response = await controller.GetSuggestsCompaniesLeavesAsync(null);
            var result = response as ObjectResult;
            var value = result?.Value as ResponseModel<object?>;

            Assert.Null(value?.Result);
            Assert.Equal(400, result?.StatusCode);
            Assert.Equal(HttpStatusCode.BadRequest, value?.Status?.Code);
        }

        [Fact]
        public async Task GetSuggestsCompaniesLeavesAsync_WithEmptySearchStringParam_ReturnBadRequestResponseWithNullResult()
        {
            var controller = new SuggestsController(_service.Object);

            var response = await controller.GetSuggestsCompaniesLeavesAsync("");
            var result = response as ObjectResult;
            var value = result?.Value as ResponseModel<object?>;

            Assert.Null(value?.Result);
            Assert.Equal(400, result?.StatusCode);
            Assert.Equal(HttpStatusCode.BadRequest, value?.Status?.Code);
        }

        [Fact]
        public async Task GetSuggestsCompaniesLeavesAsync_WhenSearchStringParamHaveLengthLessThanMinLengthSearchString_ReturnBadRequestResponseWithNullResult()
        {
            var controller = new SuggestsController(_service.Object);

            var response = await controller.GetSuggestsCompaniesLeavesAsync("ДН");
            var result = response as ObjectResult;
            var value = result?.Value as ResponseModel<object?>;

            Assert.Null(value?.Result);
            Assert.Equal(400, result?.StatusCode);
            Assert.Equal(HttpStatusCode.BadRequest, value?.Status?.Code);
        }

        [Fact]
        public async Task GetSuggestsCompaniesLeavesAsync_WithValidSearchStringParam_ReturnSuccessResponseWithNotEmptyResult()
        {
            var controller = new SuggestsController(_service.Object);

            var response = await controller.GetSuggestsCompaniesLeavesAsync("ДНС");
            var result = response as ObjectResult;
            var value = result?.Value as ResponseModel<ItemsResponseModel<Employer>>;

            Assert.NotEmpty(value?.Result?.Items);
            Assert.Equal(200, result?.StatusCode);
            Assert.Equal(HttpStatusCode.OK, value?.Status?.Code);
        }

        [Fact]
        public async Task GetSuggestsUniversitiesAsync_WithNullSearchStringParam_ReturnBadRequestResponseWithNullResult()
        {
            var controller = new SuggestsController(_service.Object);

            var response = await controller.GetSuggestsUniversitiesAsync(null);
            var result = response as ObjectResult;
            var value = result?.Value as ResponseModel<object?>;

            Assert.Null(value?.Result);
            Assert.Equal(400, result?.StatusCode);
            Assert.Equal(HttpStatusCode.BadRequest, value?.Status?.Code);
        }

        [Fact]
        public async Task GetSuggestsUniversitiesAsync_WithEmptySearchStringParam_ReturnBadRequestResponseWithNullResult()
        {
            var controller = new SuggestsController(_service.Object);

            var response = await controller.GetSuggestsUniversitiesAsync("");
            var result = response as ObjectResult;
            var value = result?.Value as ResponseModel<object?>;

            Assert.Null(value?.Result);
            Assert.Equal(400, result?.StatusCode);
            Assert.Equal(HttpStatusCode.BadRequest, value?.Status?.Code);
        }

        [Fact]
        public async Task GetSuggestsUniversitiesAsync_WhenSearchStringParamHaveLengthLessThanMinLengthSearchString_ReturnBadRequestResponseWithNullResult()
        {
            var controller = new SuggestsController(_service.Object);

            var response = await controller.GetSuggestsUniversitiesAsync("МГ");
            var result = response as ObjectResult;
            var value = result?.Value as ResponseModel<object?>;

            Assert.Null(value?.Result);
            Assert.Equal(400, result?.StatusCode);
            Assert.Equal(HttpStatusCode.BadRequest, value?.Status?.Code);
        }

        [Fact]
        public async Task GetSuggestsUniversitiesAsync_WithValidSearchStringParam_ReturnSuccessResponseWithNotEmptyResult()
        {
            var controller = new SuggestsController(_service.Object);

            var response = await controller.GetSuggestsUniversitiesAsync("МГУ");
            var result = response as ObjectResult;
            var value = result?.Value as ResponseModel<ItemsResponseModel<University>>;

            Assert.NotEmpty(value?.Result?.Items);
            Assert.Equal(200, result?.StatusCode);
            Assert.Equal(HttpStatusCode.OK, value?.Status?.Code);
        }

        [Fact]
        public async Task GetSuggestsSpecializationsAsync_WithNullSearchStringParam_ReturnBadRequestResponseWithNullResult()
        {
            var controller = new SuggestsController(_service.Object);

            var response = await controller.GetSuggestsSpecializationsAsync(null);
            var result = response as ObjectResult;
            var value = result?.Value as ResponseModel<object?>;

            Assert.Null(value?.Result);
            Assert.Equal(400, result?.StatusCode);
            Assert.Equal(HttpStatusCode.BadRequest, value?.Status?.Code);
        }

        [Fact]
        public async Task GetSuggestsSpecializationsAsync_WithEmptySearchStringParam_ReturnBadRequestResponseWithNullResult()
        {
            var controller = new SuggestsController(_service.Object);

            var response = await controller.GetSuggestsSpecializationsAsync("");
            var result = response as ObjectResult;
            var value = result?.Value as ResponseModel<object?>;

            Assert.Null(value?.Result);
            Assert.Equal(400, result?.StatusCode);
            Assert.Equal(HttpStatusCode.BadRequest, value?.Status?.Code);
        }

        [Fact]
        public async Task GetSuggestsSpecializationsAsync_WhenSearchStringParamHaveLengthLessThanMinLengthSearchString_ReturnBadRequestResponseWithNullResult()
        {
            var controller = new SuggestsController(_service.Object);

            var response = await controller.GetSuggestsSpecializationsAsync("Ко");
            var result = response as ObjectResult;
            var value = result?.Value as ResponseModel<object?>;

            Assert.Null(value?.Result);
            Assert.Equal(400, result?.StatusCode);
            Assert.Equal(HttpStatusCode.BadRequest, value?.Status?.Code);
        }

        [Fact]
        public async Task GetSuggestsSpecializationsAsync_WithValidSearchStringParam_ReturnSuccessResponseWithNotEmptyResult()
        {
            var controller = new SuggestsController(_service.Object);

            var response = await controller.GetSuggestsSpecializationsAsync("Ком");
            var result = response as ObjectResult;
            var value = result?.Value as ResponseModel<ItemsResponseModel<Specialization>>;

            Assert.NotEmpty(value?.Result?.Items);
            Assert.Equal(200, result?.StatusCode);
            Assert.Equal(HttpStatusCode.OK, value?.Status?.Code);
        }

        [Fact]
        public async Task GetSuggestsProfessionalRolesAsync_WithNullSearchStringParam_ReturnBadRequestResponseWithNullResult()
        {
            var controller = new SuggestsController(_service.Object);

            var response = await controller.GetSuggestsProfessionalRolesAsync(null);
            var result = response as ObjectResult;
            var value = result?.Value as ResponseModel<object?>;

            Assert.Null(value?.Result);
            Assert.Equal(400, result?.StatusCode);
            Assert.Equal(HttpStatusCode.BadRequest, value?.Status?.Code);
        }

        [Fact]
        public async Task GetSuggestsProfessionalRolesAsync_WithEmptySearchStringParam_ReturnBadRequestResponseWithNullResult()
        {
            var controller = new SuggestsController(_service.Object);

            var response = await controller.GetSuggestsProfessionalRolesAsync("");
            var result = response as ObjectResult;
            var value = result?.Value as ResponseModel<object?>;

            Assert.Null(value?.Result);
            Assert.Equal(400, result?.StatusCode);
            Assert.Equal(HttpStatusCode.BadRequest, value?.Status?.Code);
        }

        [Fact]
        public async Task GetSuggestsProfessionalRolesAsync_WhenSearchStringParamHaveLengthLessThanMinLengthSearchString_ReturnBadRequestResponseWithNullResult()
        {
            var controller = new SuggestsController(_service.Object);

            var response = await controller.GetSuggestsProfessionalRolesAsync("Во");
            var result = response as ObjectResult;
            var value = result?.Value as ResponseModel<object?>;

            Assert.Null(value?.Result);
            Assert.Equal(400, result?.StatusCode);
            Assert.Equal(HttpStatusCode.BadRequest, value?.Status?.Code);
        }

        [Fact]
        public async Task GetSuggestsProfessionalRolesAsync_WithValidSearchStringParam_ReturnSuccessResponseWithNotEmptyResult()
        {
            var controller = new SuggestsController(_service.Object);

            var response = await controller.GetSuggestsProfessionalRolesAsync("Водитель");
            var result = response as ObjectResult;
            var value = result?.Value as ResponseModel<ItemsResponseModel<ProfessionalRole>>;

            Assert.NotEmpty(value?.Result?.Items);
            Assert.Equal(200, result?.StatusCode);
            Assert.Equal(HttpStatusCode.OK, value?.Status?.Code);
        }

        [Fact]
        public async Task GetSuggestsKeySkillsAsync_WithNullSearchStringParam_ReturnBadRequestResponseWithNullResult()
        {
            var controller = new SuggestsController(_service.Object);

            var response = await controller.GetSuggestsKeySkillsAsync(null);
            var result = response as ObjectResult;
            var value = result?.Value as ResponseModel<object?>;

            Assert.Null(value?.Result);
            Assert.Equal(400, result?.StatusCode);
            Assert.Equal(HttpStatusCode.BadRequest, value?.Status?.Code);
        }

        [Fact]
        public async Task GetSuggestsKeySkillsAsync_WithEmptySearchStringParam_ReturnBadRequestResponseWithNullResult()
        {
            var controller = new SuggestsController(_service.Object);

            var response = await controller.GetSuggestsKeySkillsAsync("");
            var result = response as ObjectResult;
            var value = result?.Value as ResponseModel<object?>;

            Assert.Null(value?.Result);
            Assert.Equal(400, result?.StatusCode);
            Assert.Equal(HttpStatusCode.BadRequest, value?.Status?.Code);
        }

        [Fact]
        public async Task GetSuggestsKeySkillsAsync_WhenSearchStringParamHaveLengthLessThanMinLengthSearchString_ReturnBadRequestResponseWithNullResult()
        {
            var controller = new SuggestsController(_service.Object);

            var response = await controller.GetSuggestsKeySkillsAsync("AS");
            var result = response as ObjectResult;
            var value = result?.Value as ResponseModel<object?>;

            Assert.Null(value?.Result);
            Assert.Equal(400, result?.StatusCode);
            Assert.Equal(HttpStatusCode.BadRequest, value?.Status?.Code);
        }

        [Fact]
        public async Task GetSuggestsKeySkillsAsync_WithValidSearchStringParam_ReturnSuccessResponseWithNotEmptyResult()
        {
            var controller = new SuggestsController(_service.Object);

            var response = await controller.GetSuggestsKeySkillsAsync("ASP.NET");
            var result = response as ObjectResult;
            var value = result?.Value as ResponseModel<ItemsResponseModel<KeySkill>>;

            Assert.NotEmpty(value?.Result?.Items);
            Assert.Equal(200, result?.StatusCode);
            Assert.Equal(HttpStatusCode.OK, value?.Status?.Code);
        }

        [Fact]
        public async Task GetSuggestsVacancyPositionsAsync_WithNullSearchStringParam_ReturnBadRequestResponseWithNullResult()
        {
            var controller = new SuggestsController(_service.Object);

            var response = await controller.GetSuggestsVacancyPositionsAsync(null);
            var result = response as ObjectResult;
            var value = result?.Value as ResponseModel<object?>;

            Assert.Null(value?.Result);
            Assert.Equal(400, result?.StatusCode);
            Assert.Equal(HttpStatusCode.BadRequest, value?.Status?.Code);
        }

        [Fact]
        public async Task GetSuggestsVacancyPositionsAsync_WithEmptySearchStringParam_ReturnBadRequestResponseWithNullResult()
        {
            var controller = new SuggestsController(_service.Object);

            var response = await controller.GetSuggestsVacancyPositionsAsync("");
            var result = response as ObjectResult;
            var value = result?.Value as ResponseModel<object?>;

            Assert.Null(value?.Result);
            Assert.Equal(400, result?.StatusCode);
            Assert.Equal(HttpStatusCode.BadRequest, value?.Status?.Code);
        }

        [Fact]
        public async Task GetSuggestsVacancyPositionsAsync_WhenSearchStringParamHaveLengthLessThanMinLengthSearchString_ReturnBadRequestResponseWithNullResult()
        {
            var controller = new SuggestsController(_service.Object);

            var response = await controller.GetSuggestsVacancyPositionsAsync("Пр");
            var result = response as ObjectResult;
            var value = result?.Value as ResponseModel<object?>;

            Assert.Null(value?.Result);
            Assert.Equal(400, result?.StatusCode);
            Assert.Equal(HttpStatusCode.BadRequest, value?.Status?.Code);
        }

        [Fact]
        public async Task GetSuggestsVacancyPositionsAsync_WithValidSearchStringParam_ReturnSuccessResponseWithNotEmptyResult()
        {
            var controller = new SuggestsController(_service.Object);

            var response = await controller.GetSuggestsVacancyPositionsAsync("Программист");
            var result = response as ObjectResult;
            var value = result?.Value as ResponseModel<ItemsResponseModel<VacancyPosition>>;

            Assert.NotEmpty(value?.Result?.Items);
            Assert.Equal(200, result?.StatusCode);
            Assert.Equal(HttpStatusCode.OK, value?.Status?.Code);
        }

        [Fact]
        public async Task GetSuggestsVacancyKeyWordsAsync_WithNullSearchStringParam_ReturnBadRequestResponseWithNullResult()
        {
            var controller = new SuggestsController(_service.Object);

            var response = await controller.GetSuggestsVacancyKeyWordsAsync(null);
            var result = response as ObjectResult;
            var value = result?.Value as ResponseModel<object?>;

            Assert.Null(value?.Result);
            Assert.Equal(400, result?.StatusCode);
            Assert.Equal(HttpStatusCode.BadRequest, value?.Status?.Code);
        }

        [Fact]
        public async Task GetSuggestsVacancyKeyWordsAsync_WithEmptySearchStringParam_ReturnBadRequestResponseWithNullResult()
        {
            var controller = new SuggestsController(_service.Object);

            var response = await controller.GetSuggestsVacancyKeyWordsAsync("");
            var result = response as ObjectResult;
            var value = result?.Value as ResponseModel<object?>;

            Assert.Null(value?.Result);
            Assert.Equal(400, result?.StatusCode);
            Assert.Equal(HttpStatusCode.BadRequest, value?.Status?.Code);
        }

        [Fact]
        public async Task GetSuggestsVacancyKeyWordsAsync_WhenSearchStringParamHaveLengthLessThanMinLengthSearchString_ReturnBadRequestResponseWithNullResult()
        {
            var controller = new SuggestsController(_service.Object);

            var response = await controller.GetSuggestsVacancyKeyWordsAsync("Ju");
            var result = response as ObjectResult;
            var value = result?.Value as ResponseModel<object?>;

            Assert.Null(value?.Result);
            Assert.Equal(400, result?.StatusCode);
            Assert.Equal(HttpStatusCode.BadRequest, value?.Status?.Code);
        }

        [Fact]
        public async Task GetSuggestsVacancyKeyWordsAsync_WithValidSearchStringParam_ReturnSuccessResponseWithNotEmptyResult()
        {
            var controller = new SuggestsController(_service.Object);

            var response = await controller.GetSuggestsVacancyKeyWordsAsync("Junior");
            var result = response as ObjectResult;
            var value = result?.Value as ResponseModel<ItemsResponseModel<KeyWord>>;

            Assert.NotEmpty(value?.Result?.Items);
            Assert.Equal(200, result?.StatusCode);
            Assert.Equal(HttpStatusCode.OK, value?.Status?.Code);
        }
    }
}
