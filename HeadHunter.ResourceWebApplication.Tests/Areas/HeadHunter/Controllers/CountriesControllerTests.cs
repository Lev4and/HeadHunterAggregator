using HeadHunter.HttpClients;
using HeadHunter.Model.Common;
using HeadHunter.Models;
using HeadHunter.ResourceWebApplication.Areas.HeadHunter.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Net;

namespace HeadHunter.ResourceWebApplication.Tests.Areas.HeadHunter.Controllers
{
    public class CountriesControllerTests
    {
        private readonly Mock<HttpContext> _service;

        public CountriesControllerTests()
        {
            _service = new Mock<HttpContext>();
        }

        [Fact]
        public async Task GetAllCountriesAsync_ReturnSuccessResponseWithNotEmptyResult()
        {
            var controller = new CountriesController(_service.Object);

            var response = await controller.GetAllCountriesAsync();
            var result = response as ObjectResult;
            var value = result?.Value as ResponseModel<Country[]>;

            Assert.NotEmpty(value?.Result);
            Assert.Equal(200, result?.StatusCode);
            Assert.Equal(HttpStatusCode.OK, value?.Status?.Code);
        }
    }
}
