using HeadHunter.HttpClients.HeadHunter;
using System.Net;

namespace HeadHunter.HttpClients.Tests.HeadHunter
{
    public class UniversitiesHttpClientTests
    {
        private readonly HttpContext _context;

        public UniversitiesHttpClientTests()
        {
            _context = new HttpContext();
        }

        [Fact]
        public async Task GetUniversityAsync_WithInvalidIdParam_ThrowException()
        {
            var action = async () => { await _context.HeadHunter.Universities.GetUniversityAsync(HeadHunterConstants.IdLowerValue - 1); };

            await Assert.ThrowsAsync<ArgumentOutOfRangeException>(action);
        }

        [Fact]
        public async Task GetUniversityAsync_WithNotExistsIdParam_ReturnSuccessResponseWithEmptyResult()
        {
            var response = await _context.HeadHunter.Universities.GetUniversityAsync(HeadHunterConstants.IdLowerValue);
            var statusCode = response.Status.Code;

            Assert.NotNull(response);
            Assert.NotNull(response.Result);
            Assert.Empty(response?.Result?.Items);
            Assert.Equal(HttpStatusCode.OK, statusCode);
        }

        [Fact]
        public async Task GetUniversityAsync_WithValidIdParam_ReturnSuccessResponseWithNotEmptyResult()
        {
            var response = await _context.HeadHunter.Universities.GetUniversityAsync(45470);
            var statusCode = response.Status.Code;

            Assert.NotNull(response);
            Assert.NotNull(response.Result);
            Assert.NotEmpty(response?.Result?.Items);
            Assert.Equal(HttpStatusCode.OK, statusCode);
        }

        [Fact]
        public async Task GetUniversitiesAsync_WithNullIdsParam_ThrowException()
        {
            var action = async () => { await _context.HeadHunter.Universities.GetUniversitiesAsync(null); };

            await Assert.ThrowsAsync<ArgumentNullException>(action);
        }

        [Fact]
        public async Task GetUniversitiesAsync_WithEmptyIdsParam_ThrowException()
        {
            var action = async () => { await _context.HeadHunter.Universities.GetUniversitiesAsync(new int[0]); };

            await Assert.ThrowsAsync<ArgumentNullException>(action);
        }

        [Fact]
        public async Task GetUniversitiesAsync_WhenSomeItemOfIdsParamNotValid_ThrowException()
        {
            var ids = new int[3] { -1, 45470, 39196 };
            var action = async () => { await _context.HeadHunter.Universities.GetUniversitiesAsync(ids); };

            await Assert.ThrowsAsync<ArgumentOutOfRangeException>(action);
        }

        [Fact]
        public async Task GetUniversitiesAsync_WhenAllItemsOfIdsParamValid_ReturnSuccessResponseWithNotEmptyResult()
        {
            var ids = new int[2] { 45470, 39196 };
            var response = await _context.HeadHunter.Universities.GetUniversitiesAsync(ids);
            var statusCode = response.Status.Code;

            Assert.NotNull(response);
            Assert.NotNull(response.Result);
            Assert.NotEmpty(response?.Result?.Items);
            Assert.Equal(2, response?.Result?.Items?.Length);
            Assert.Equal(HttpStatusCode.OK, statusCode);
        }

        [Fact]
        public async Task GetUniversitiesAsync_WhenSomeItemOfIdsParamNotExists_ReturnSuccessResponseWithNotEmptyResult()
        {
            var ids = new int[3] { HeadHunterConstants.IdLowerValue, 45470, 39196 };
            var response = await _context.HeadHunter.Universities.GetUniversitiesAsync(ids);
            var statusCode = response.Status.Code;

            Assert.NotNull(response);
            Assert.NotNull(response.Result);
            Assert.NotEmpty(response?.Result?.Items);
            Assert.Equal(2, response?.Result?.Items?.Length);
            Assert.Equal(HttpStatusCode.OK, statusCode);
        }

        [Fact]
        public async Task GetAllFacultiesByUniversityIdAsync_WithInvalidUniversityIdParam_ThrowException()
        {
            var action = async () => { await _context.HeadHunter.Universities.GetAllFacultiesByUniversityIdAsync(0); };

            await Assert.ThrowsAsync<ArgumentOutOfRangeException>(action);
        }

        [Fact]
        public async Task GetAllFacultiesByUniversityIdAsync_WithValidUniversityIdParam_ReturnNotFoundResponseWithNotEmptyResult()
        {
            var response = await _context.HeadHunter.Universities.GetAllFacultiesByUniversityIdAsync(45470);
            var statusCode = response.Status.Code;

            Assert.NotNull(response);
            Assert.NotEmpty(response.Result);
            Assert.Equal(HttpStatusCode.OK, statusCode);
        }
    }
}
