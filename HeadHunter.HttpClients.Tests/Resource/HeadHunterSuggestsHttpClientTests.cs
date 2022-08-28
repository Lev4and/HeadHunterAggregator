using System.Net;

namespace HeadHunter.HttpClients.Tests.Resource
{
    public class HeadHunterSuggestsHttpClientTests
    {
        private readonly HttpContext _context;

        public HeadHunterSuggestsHttpClientTests()
        {
            _context = new HttpContext();
        }

        [Fact]
        public async Task GetSuggestsAreaAsync_WithNullSearchStringParam_ThrowException()
        {
            var action = async () => { await _context.Resource.HeadHunterSuggests.GetSuggestsAreaAsync(null); };

            await Assert.ThrowsAsync<ArgumentNullException>(action);
        }

        [Fact]
        public async Task GetSuggestsAreaAsync_WithEmptySearchStringParam_ThrowException()
        {
            var action = async () => { await _context.Resource.HeadHunterSuggests.GetSuggestsAreaAsync(""); };

            await Assert.ThrowsAsync<ArgumentNullException>(action);
        }

        [Fact]
        public async Task GetSuggestsAreaAsync_WhenSearchStringParamHaveLengthLessThanMinLengthSearchString_ThrowException()
        {
            var action = async () => { await _context.Resource.HeadHunterSuggests.GetSuggestsAreaAsync("Мо"); };

            await Assert.ThrowsAsync<ArgumentOutOfRangeException>(action);
        }

        [Fact]
        public async Task GetSuggestsAreaAsync_WithValidSearchStringParam_ReturnSuccessResponseWithNotEmptyResult()
        {
            var response = await _context.Resource.HeadHunterSuggests.GetSuggestsAreaAsync("Моск");
            var statusCode = response.Status.Code;

            Assert.NotNull(response);
            Assert.NotNull(response.Result);
            Assert.NotEmpty(response?.Result?.Items);
            Assert.Equal(HttpStatusCode.OK, statusCode);
        }

        [Fact]
        public async Task GetSuggestsCompaniesAsync_WithNullSearchStringParam_ThrowException()
        {
            var action = async () => { await _context.Resource.HeadHunterSuggests.GetSuggestsCompaniesAsync(null); };

            await Assert.ThrowsAsync<ArgumentNullException>(action);
        }

        [Fact]
        public async Task GetSuggestsCompaniesAsync_WithEmptySearchStringParam_ThrowException()
        {
            var action = async () => { await _context.Resource.HeadHunterSuggests.GetSuggestsCompaniesAsync(""); };

            await Assert.ThrowsAsync<ArgumentNullException>(action);
        }

        [Fact]
        public async Task GetSuggestsCompaniesAsync_WhenSearchStringParamHaveLengthLessThanMinLengthSearchString_ThrowException()
        {
            var action = async () => { await _context.Resource.HeadHunterSuggests.GetSuggestsCompaniesAsync("ДН"); };

            await Assert.ThrowsAsync<ArgumentOutOfRangeException>(action);
        }

        [Fact]
        public async Task GetSuggestsCompaniesAsync_WithValidSearchStringParam_ReturnSuccessResponseWithNotEmptyResult()
        {
            var response = await _context.Resource.HeadHunterSuggests.GetSuggestsCompaniesAsync("ДНС");
            var statusCode = response.Status.Code;

            Assert.NotNull(response);
            Assert.NotNull(response.Result);
            Assert.NotEmpty(response?.Result?.Items);
            Assert.Equal(HttpStatusCode.OK, statusCode);
        }

        [Fact]
        public async Task GetSuggestsKeySkillsAsync_WithNullSearchStringParam_ThrowException()
        {
            var action = async () => { await _context.Resource.HeadHunterSuggests.GetSuggestsKeySkillsAsync(null); };

            await Assert.ThrowsAsync<ArgumentNullException>(action);
        }

        [Fact]
        public async Task GetSuggestsKeySkillsAsync_WithEmptySearchStringParam_ThrowException()
        {
            var action = async () => { await _context.Resource.HeadHunterSuggests.GetSuggestsKeySkillsAsync(""); };

            await Assert.ThrowsAsync<ArgumentNullException>(action);
        }

        [Fact]
        public async Task GetSuggestsKeySkillsAsync_WhenSearchStringParamHaveLengthLessThanMinLengthSearchString_ThrowException()
        {
            var action = async () => { await _context.Resource.HeadHunterSuggests.GetSuggestsKeySkillsAsync("AS"); };

            await Assert.ThrowsAsync<ArgumentOutOfRangeException>(action);
        }

        [Fact]
        public async Task GetSuggestsKeySkillsAsync_WithValidSearchStringParam_ReturnSuccessResponseWithNotEmptyResult()
        {
            var response = await _context.Resource.HeadHunterSuggests.GetSuggestsKeySkillsAsync("ASP.NET");
            var statusCode = response.Status.Code;

            Assert.NotNull(response);
            Assert.NotNull(response.Result);
            Assert.NotEmpty(response?.Result?.Items);
            Assert.Equal(HttpStatusCode.OK, statusCode);
        }

        [Fact]
        public async Task GetSuggestsProfessionalRolesAsync_WithNullSearchStringParam_ThrowException()
        {
            var action = async () => { await _context.Resource.HeadHunterSuggests.GetSuggestsProfessionalRolesAsync(null); };

            await Assert.ThrowsAsync<ArgumentNullException>(action);
        }

        [Fact]
        public async Task GetSuggestsProfessionalRolesAsync_WithEmptySearchStringParam_ThrowException()
        {
            var action = async () => { await _context.Resource.HeadHunterSuggests.GetSuggestsProfessionalRolesAsync(""); };

            await Assert.ThrowsAsync<ArgumentNullException>(action);
        }

        [Fact]
        public async Task GetSuggestsProfessionalRolesAsync_WhenSearchStringParamHaveLengthLessThanMinLengthSearchString_ThrowException()
        {
            var action = async () => { await _context.Resource.HeadHunterSuggests.GetSuggestsProfessionalRolesAsync("Во"); };

            await Assert.ThrowsAsync<ArgumentOutOfRangeException>(action);
        }

        [Fact]
        public async Task GetSuggestsProfessionalRolesAsync_WithValidSearchStringParam_ReturnSuccessResponseWithNotEmptyResult()
        {
            var response = await _context.Resource.HeadHunterSuggests.GetSuggestsProfessionalRolesAsync("Вод");
            var statusCode = response.Status.Code;

            Assert.NotNull(response);
            Assert.NotNull(response.Result);
            Assert.NotEmpty(response?.Result?.Items);
            Assert.Equal(HttpStatusCode.OK, statusCode);
        }

        [Fact]
        public async Task GetSuggestsSpecializationsAsync_WithNullSearchStringParam_ThrowException()
        {
            var action = async () => { await _context.Resource.HeadHunterSuggests.GetSuggestsSpecializationsAsync(null); };

            await Assert.ThrowsAsync<ArgumentNullException>(action);
        }

        [Fact]
        public async Task GetSuggestsSpecializationsAsync_WithEmptySearchStringParam_ThrowException()
        {
            var action = async () => { await _context.Resource.HeadHunterSuggests.GetSuggestsSpecializationsAsync(""); };

            await Assert.ThrowsAsync<ArgumentNullException>(action);
        }

        [Fact]
        public async Task GetSuggestsSpecializationsAsync_WhenSearchStringParamHaveLengthLessThanMinLengthSearchString_ThrowException()
        {
            var action = async () => { await _context.Resource.HeadHunterSuggests.GetSuggestsSpecializationsAsync("Ко"); };

            await Assert.ThrowsAsync<ArgumentOutOfRangeException>(action);
        }

        [Fact]
        public async Task GetSuggestsSpecializationsAsync_WithValidSearchStringParam_ReturnSuccessResponseWithNotEmptyResult()
        {
            var response = await _context.Resource.HeadHunterSuggests.GetSuggestsSpecializationsAsync("Ком");
            var statusCode = response.Status.Code;

            Assert.NotNull(response);
            Assert.NotNull(response.Result);
            Assert.NotEmpty(response?.Result?.Items);
            Assert.Equal(HttpStatusCode.OK, statusCode);
        }

        [Fact]
        public async Task GetSuggestsUniversitiesAsync_WithNullSearchStringParam_ThrowException()
        {
            var action = async () => { await _context.Resource.HeadHunterSuggests.GetSuggestsUniversitiesAsync(null); };

            await Assert.ThrowsAsync<ArgumentNullException>(action);
        }

        [Fact]
        public async Task GetSuggestsUniversitiesAsync_WithEmptySearchStringParam_ThrowException()
        {
            var action = async () => { await _context.Resource.HeadHunterSuggests.GetSuggestsUniversitiesAsync(""); };

            await Assert.ThrowsAsync<ArgumentNullException>(action);
        }

        [Fact]
        public async Task GetSuggestsUniversitiesAsync_WhenSearchStringParamHaveLengthLessThanMinLengthSearchString_ThrowException()
        {
            var action = async () => { await _context.Resource.HeadHunterSuggests.GetSuggestsUniversitiesAsync("МГ"); };

            await Assert.ThrowsAsync<ArgumentOutOfRangeException>(action);
        }

        [Fact]
        public async Task GetSuggestsUniversitiesAsync_WithValidSearchStringParam_ReturnSuccessResponseWithNotEmptyResult()
        {
            var response = await _context.Resource.HeadHunterSuggests.GetSuggestsUniversitiesAsync("МГУ");
            var statusCode = response.Status.Code;

            Assert.NotNull(response);
            Assert.NotNull(response.Result);
            Assert.NotEmpty(response?.Result?.Items);
            Assert.Equal(HttpStatusCode.OK, statusCode);
        }

        [Fact]
        public async Task GetSuggestsVacancyPositionsAsync_WithNullSearchStringParam_ThrowException()
        {
            var action = async () => { await _context.Resource.HeadHunterSuggests.GetSuggestsVacancyPositionsAsync(null); };

            await Assert.ThrowsAsync<ArgumentNullException>(action);
        }

        [Fact]
        public async Task GetSuggestsVacancyPositionsAsync_WithEmptySearchStringParam_ThrowException()
        {
            var action = async () => { await _context.Resource.HeadHunterSuggests.GetSuggestsVacancyPositionsAsync(""); };

            await Assert.ThrowsAsync<ArgumentNullException>(action);
        }

        [Fact]
        public async Task GetSuggestsVacancyPositionsAsync_WhenSearchStringParamHaveLengthLessThanMinLengthSearchString_ThrowException()
        {
            var action = async () => { await _context.Resource.HeadHunterSuggests.GetSuggestsVacancyPositionsAsync("Пр"); };

            await Assert.ThrowsAsync<ArgumentOutOfRangeException>(action);
        }

        [Fact]
        public async Task GetSuggestsVacancyPositionsAsync_WithValidSearchStringParam_ReturnSuccessResponseWithNotEmptyResult()
        {
            var response = await _context.Resource.HeadHunterSuggests.GetSuggestsVacancyPositionsAsync("Программист");
            var statusCode = response.Status.Code;

            Assert.NotNull(response);
            Assert.NotNull(response.Result);
            Assert.NotEmpty(response?.Result?.Items);
            Assert.Equal(HttpStatusCode.OK, statusCode);
        }

        [Fact]
        public async Task GetSuggestsVacancyKeyWordsAsync_WithNullSearchStringParam_ThrowException()
        {
            var action = async () => { await _context.Resource.HeadHunterSuggests.GetSuggestsVacancyKeyWordsAsync(null); };

            await Assert.ThrowsAsync<ArgumentNullException>(action);
        }

        [Fact]
        public async Task GetSuggestsVacancyKeyWordsAsync_WithEmptySearchStringParam_ThrowException()
        {
            var action = async () => { await _context.Resource.HeadHunterSuggests.GetSuggestsVacancyKeyWordsAsync(""); };

            await Assert.ThrowsAsync<ArgumentNullException>(action);
        }

        [Fact]
        public async Task GetSuggestsVacancyKeyWordsAsync_WhenSearchStringParamHaveLengthLessThanMinLengthSearchString_ThrowException()
        {
            var action = async () => { await _context.Resource.HeadHunterSuggests.GetSuggestsVacancyKeyWordsAsync("Ju"); };

            await Assert.ThrowsAsync<ArgumentOutOfRangeException>(action);
        }

        [Fact]
        public async Task GetSuggestsVacancyKeyWordsAsync_WithValidSearchStringParam_ReturnSuccessResponseWithNotEmptyResult()
        {
            var response = await _context.Resource.HeadHunterSuggests.GetSuggestsVacancyKeyWordsAsync("Junior");
            var statusCode = response.Status.Code;

            Assert.NotNull(response);
            Assert.NotNull(response.Result);
            Assert.NotEmpty(response?.Result?.Items);
            Assert.Equal(HttpStatusCode.OK, statusCode);
        }
    }
}
