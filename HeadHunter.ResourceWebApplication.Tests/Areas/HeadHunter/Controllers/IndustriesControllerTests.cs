using HeadHunter.HttpClients;
using HeadHunter.Model.Common;
using HeadHunter.Models;
using HeadHunter.ResourceWebApplication.Areas.HeadHunter.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Net;

namespace HeadHunter.ResourceWebApplication.Tests.Areas.HeadHunter.Controllers
{
    public class IndustriesControllerTests
    {
        private readonly Mock<HttpContext> _service;

        public IndustriesControllerTests()
        {
            _service = new Mock<HttpContext>();
        }

        [Fact]
        public async Task GetAllIndustriesAsync_ReturnSuccessResponseWithNotEmptyResult()
        {
            var controller = new IndustriesController(_service.Object);

            var response = await controller.GetAllIndustriesAsync();
            var result = response as ObjectResult;
            var value = result?.Value as ResponseModel<Industry[]>;

            Assert.NotEmpty(value?.Result);
            Assert.Equal(200, result?.StatusCode);
            Assert.Equal(HttpStatusCode.OK, value?.Status?.Code);
        }
    }
}
