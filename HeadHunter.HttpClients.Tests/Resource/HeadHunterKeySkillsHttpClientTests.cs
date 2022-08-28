using System.Net;

namespace HeadHunter.HttpClients.Tests.Resource
{
    public class HeadHunterKeySkillsHttpClientTests
    {
        private readonly HttpContext _context;

        public HeadHunterKeySkillsHttpClientTests()
        {
            _context = new HttpContext();
        }

        [Fact]
        public async Task GetKeySkillAsync_WithInvalidIdParam_ThrowException()
        {
            var action = async () => { await _context.Resource.HeadHunterKeySkills.GetKeySkillAsync(-1); };

            await Assert.ThrowsAsync<ArgumentOutOfRangeException>(action);
        }

        [Fact]
        public async Task GetKeySkillAsync_WithNotExistsIdParam_ReturnSuccessResponseWithEmptyResult()
        {
            var response = await _context.Resource.HeadHunterKeySkills.GetKeySkillAsync(123456789);
            var statusCode = response.Status.Code;

            Assert.NotNull(response);
            Assert.NotNull(response.Result);
            Assert.Empty(response?.Result?.Items);
            Assert.Equal(HttpStatusCode.OK, statusCode);
        }

        [Fact]
        public async Task GetKeySkillAsync_WithValidIdParam_ReturnSuccessResponseWithNotEmptyResult()
        {
            var response = await _context.Resource.HeadHunterKeySkills.GetKeySkillAsync(1);
            var statusCode = response.Status.Code;

            Assert.NotNull(response);
            Assert.NotNull(response.Result);
            Assert.NotEmpty(response?.Result?.Items);
            Assert.Equal(HttpStatusCode.OK, statusCode);
        }

        [Fact]
        public async Task GetKeySkillsAsync_WithNullIdsParam_ThrowException()
        {
            var action = async () => { await _context.Resource.HeadHunterKeySkills.GetKeySkillsAsync(null); };

            await Assert.ThrowsAsync<ArgumentNullException>(action);
        }

        [Fact]
        public async Task GetKeySkillsAsync_WithEmptyIdsParam_ThrowException()
        {
            var action = async () => { await _context.Resource.HeadHunterKeySkills.GetKeySkillsAsync(new int[0]); };

            await Assert.ThrowsAsync<ArgumentNullException>(action);
        }

        [Fact]
        public async Task GetKeySkillsAsync_WhenSomeItemOfIdsParamNotValid_ThrowException()
        {
            var ids = new int[3] { 1, 2, -1 };
            var action = async () => { await _context.Resource.HeadHunterKeySkills.GetKeySkillsAsync(ids); };

            await Assert.ThrowsAsync<ArgumentOutOfRangeException>(action);
        }

        [Fact]
        public async Task GetKeySkillsAsync_WhenAllItemsOfIdsParamValid_ReturnSuccessResponseWithNotEmptyResult()
        {
            var ids = new int[3] { 1, 2, 3 };
            var response = await _context.Resource.HeadHunterKeySkills.GetKeySkillsAsync(ids);
            var statusCode = response.Status.Code;

            Assert.NotNull(response);
            Assert.NotNull(response.Result);
            Assert.NotEmpty(response?.Result?.Items);
            Assert.Equal(3, response?.Result?.Items?.Length);
            Assert.Equal(HttpStatusCode.OK, statusCode);
        }

        [Fact]
        public async Task GetKeySkillsAsync_WhenSomeItemOfIdsParamNotExists_ReturnSuccessResponseWithNotEmptyResult()
        {
            var ids = new int[3] { 1, 2, 123456789 };
            var response = await _context.Resource.HeadHunterKeySkills.GetKeySkillsAsync(ids);
            var statusCode = response.Status.Code;

            Assert.NotNull(response);
            Assert.NotNull(response.Result);
            Assert.NotEmpty(response?.Result?.Items);
            Assert.Equal(2, response?.Result?.Items?.Length);
            Assert.Equal(HttpStatusCode.OK, statusCode);
        }
    }
}
