using HeadHunter.HttpClients;
using HeadHunter.Model.Common;
using HeadHunter.Models;
using HeadHunter.ResourceWebApplication.Areas.HeadHunter.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Net;

namespace HeadHunter.ResourceWebApplication.Tests.Areas.HeadHunter.Controllers
{
    public class SpecializationsControllerTests
    {
        private readonly Mock<HttpContext> _service;

        public SpecializationsControllerTests()
        {
            _service = new Mock<HttpContext>();
        }

        [Fact]
        public async Task GetAllSpecializationsAsync_ReturnSuccessResponseWithNotEmptyResult()
        {
            var controller = new SpecializationsController(_service.Object);

            var response = await controller.GetAllSpecializationsAsync();
            var result = response as ObjectResult;
            var value = result?.Value as ResponseModel<Specialization[]>;

            Assert.NotEmpty(value?.Result);
            Assert.Equal(200, result?.StatusCode);
            Assert.Equal(HttpStatusCode.OK, value?.Status?.Code);
        }
    }
}
