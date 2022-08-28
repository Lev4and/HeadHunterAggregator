using System.Net;

namespace HeadHunter.HttpClients.Tests.HeadHunter
{
    public class SuggestsHttpClientTests
    {
        private readonly HttpContext _context;

        public SuggestsHttpClientTests()
        {
            _context = new HttpContext();
        }

        [Fact]
        public async Task GetSuggestsAreaLeavesAsync_WithNullSearchStringParam_ThrowException()
        {
            var action = async () => { await _context.HeadHunter.Suggests.GetSuggestsAreaLeavesAsync(null); };

            await Assert.ThrowsAsync<ArgumentNullException>(action);
        }

        [Fact]
        public async Task GetSuggestsAreaLeavesAsync_WithEmptySearchStringParam_ThrowException()
        {
            var action = async () => { await _context.HeadHunter.Suggests.GetSuggestsAreaLeavesAsync(""); };

            await Assert.ThrowsAsync<ArgumentNullException>(action);
        }

        [Fact]
        public async Task GetSuggestsAreaLeavesAsync_WhenSearchStringParamHaveLengthLessThanMinLengthSearchString_ThrowException()
        {
            var action = async () => { await _context.HeadHunter.Suggests.GetSuggestsAreaLeavesAsync("Мо"); };

            await Assert.ThrowsAsync<ArgumentOutOfRangeException>(action);
        }

        [Fact]
        public async Task GetSuggestsAreaLeavesAsync_WithValidSearchStringParam_ReturnSuccessResponseWithNotEmptyResult()
        {
            var response = await _context.HeadHunter.Suggests.GetSuggestsAreaLeavesAsync("Моск");
            var statusCode = response.Status.Code;

            Assert.NotNull(response);
            Assert.NotNull(response.Result);
            Assert.NotEmpty(response?.Result?.Items);
            Assert.Equal(HttpStatusCode.OK, statusCode);
        }

        [Fact]
        public async Task GetSuggestsCompaniesLeavesAsync_WithNullSearchStringParam_ThrowException()
        {
            var action = async () => { await _context.HeadHunter.Suggests.GetSuggestsCompaniesLeavesAsync(null); };

            await Assert.ThrowsAsync<ArgumentNullException>(action);
        }

        [Fact]
        public async Task GetSuggestsCompaniesLeavesAsync_WithEmptySearchStringParam_ThrowException()
        {
            var action = async () => { await _context.HeadHunter.Suggests.GetSuggestsCompaniesLeavesAsync(""); };

            await Assert.ThrowsAsync<ArgumentNullException>(action);
        }

        [Fact]
        public async Task GetSuggestsCompaniesLeavesAsync_WhenSearchStringParamHaveLengthLessThanMinLengthSearchString_ThrowException()
        {
            var action = async () => { await _context.HeadHunter.Suggests.GetSuggestsCompaniesLeavesAsync("ДН"); };

            await Assert.ThrowsAsync<ArgumentOutOfRangeException>(action);
        }

        [Fact]
        public async Task GetSuggestsCompaniesLeavesAsync_WithValidSearchStringParam_ReturnSuccessResponseWithNotEmptyResult()
        {
            var response = await _context.HeadHunter.Suggests.GetSuggestsCompaniesLeavesAsync("ДНС");
            var statusCode = response.Status.Code;

            Assert.NotNull(response);
            Assert.NotNull(response.Result);
            Assert.NotEmpty(response?.Result?.Items);
            Assert.Equal(HttpStatusCode.OK, statusCode);
        }

        [Fact]
        public async Task GetSuggestsKeySkillsAsync_WithNullSearchStringParam_ThrowException()
        {
            var action = async () => { await _context.HeadHunter.Suggests.GetSuggestsKeySkillsAsync(null); };

            await Assert.ThrowsAsync<ArgumentNullException>(action);
        }

        [Fact]
        public async Task GetSuggestsKeySkillsAsync_WithEmptySearchStringParam_ThrowException()
        {
            var action = async () => { await _context.HeadHunter.Suggests.GetSuggestsKeySkillsAsync(""); };

            await Assert.ThrowsAsync<ArgumentNullException>(action);
        }

        [Fact]
        public async Task GetSuggestsKeySkillsAsync_WhenSearchStringParamHaveLengthLessThanMinLengthSearchString_ThrowException()
        {
            var action = async () => { await _context.HeadHunter.Suggests.GetSuggestsKeySkillsAsync("AS"); };

            await Assert.ThrowsAsync<ArgumentOutOfRangeException>(action);
        }

        [Fact]
        public async Task GetSuggestsKeySkillsAsync_WithValidSearchStringParam_ReturnSuccessResponseWithNotEmptyResult()
        {
            var response = await _context.HeadHunter.Suggests.GetSuggestsKeySkillsAsync("ASP.NET");
            var statusCode = response.Status.Code;

            Assert.NotNull(response);
            Assert.NotNull(response.Result);
            Assert.NotEmpty(response?.Result?.Items);
            Assert.Equal(HttpStatusCode.OK, statusCode);
        }

        [Fact]
        public async Task GetSuggestsProfessionalRolesAsync_WithNullSearchStringParam_ThrowException()
        {
            var action = async () => { await _context.HeadHunter.Suggests.GetSuggestsProfessionalRolesAsync(null); };

            await Assert.ThrowsAsync<ArgumentNullException>(action);
        }

        [Fact]
        public async Task GetSuggestsProfessionalRolesAsync_WithEmptySearchStringParam_ThrowException()
        {
            var action = async () => { await _context.HeadHunter.Suggests.GetSuggestsProfessionalRolesAsync(""); };

            await Assert.ThrowsAsync<ArgumentNullException>(action);
        }

        [Fact]
        public async Task GetSuggestsProfessionalRolesAsync_WhenSearchStringParamHaveLengthLessThanMinLengthSearchString_ThrowException()
        {
            var action = async () => { await _context.HeadHunter.Suggests.GetSuggestsProfessionalRolesAsync("Во"); };

            await Assert.ThrowsAsync<ArgumentOutOfRangeException>(action);
        }

        [Fact]
        public async Task GetSuggestsProfessionalRolesAsync_WithValidSearchStringParam_ReturnSuccessResponseWithNotEmptyResult()
        {
            var response = await _context.HeadHunter.Suggests.GetSuggestsProfessionalRolesAsync("Вод");
            var statusCode = response.Status.Code;

            Assert.NotNull(response);
            Assert.NotNull(response.Result);
            Assert.NotEmpty(response?.Result?.Items);
            Assert.Equal(HttpStatusCode.OK, statusCode);
        }

        [Fact]
        public async Task GetSuggestsSpecializationsAsync_WithNullSearchStringParam_ThrowException()
        {
            var action = async () => { await _context.HeadHunter.Suggests.GetSuggestsSpecializationsAsync(null); };

            await Assert.ThrowsAsync<ArgumentNullException>(action);
        }

        [Fact]
        public async Task GetSuggestsSpecializationsAsync_WithEmptySearchStringParam_ThrowException()
        {
            var action = async () => { await _context.HeadHunter.Suggests.GetSuggestsSpecializationsAsync(""); };

            await Assert.ThrowsAsync<ArgumentNullException>(action);
        }

        [Fact]
        public async Task GetSuggestsSpecializationsAsync_WhenSearchStringParamHaveLengthLessThanMinLengthSearchString_ThrowException()
        {
            var action = async () => { await _context.HeadHunter.Suggests.GetSuggestsSpecializationsAsync("Ко"); };

            await Assert.ThrowsAsync<ArgumentOutOfRangeException>(action);
        }

        [Fact]
        public async Task GetSuggestsSpecializationsAsync_WithValidSearchStringParam_ReturnSuccessResponseWithNotEmptyResult()
        {
            var response = await _context.HeadHunter.Suggests.GetSuggestsSpecializationsAsync("Ком");
            var statusCode = response.Status.Code;

            Assert.NotNull(response);
            Assert.NotNull(response.Result);
            Assert.NotEmpty(response?.Result?.Items);
            Assert.Equal(HttpStatusCode.OK, statusCode);
        }

        [Fact]
        public async Task GetSuggestsUniversitiesAsync_WithNullSearchStringParam_ThrowException()
        {
            var action = async () => { await _context.HeadHunter.Suggests.GetSuggestsUniversitiesAsync(null); };

            await Assert.ThrowsAsync<ArgumentNullException>(action);
        }

        [Fact]
        public async Task GetSuggestsUniversitiesAsync_WithEmptySearchStringParam_ThrowException()
        {
            var action = async () => { await _context.HeadHunter.Suggests.GetSuggestsUniversitiesAsync(""); };

            await Assert.ThrowsAsync<ArgumentNullException>(action);
        }

        [Fact]
        public async Task GetSuggestsUniversitiesAsync_WhenSearchStringParamHaveLengthLessThanMinLengthSearchString_ThrowException()
        {
            var action = async () => { await _context.HeadHunter.Suggests.GetSuggestsUniversitiesAsync("МГ"); };

            await Assert.ThrowsAsync<ArgumentOutOfRangeException>(action);
        }

        [Fact]
        public async Task GetSuggestsUniversitiesAsync_WithValidSearchStringParam_ReturnSuccessResponseWithNotEmptyResult()
        {
            var response = await _context.HeadHunter.Suggests.GetSuggestsUniversitiesAsync("МГУ");
            var statusCode = response.Status.Code;

            Assert.NotNull(response);
            Assert.NotNull(response.Result);
            Assert.NotEmpty(response?.Result?.Items);
            Assert.Equal(HttpStatusCode.OK, statusCode);
        }

        [Fact]
        public async Task GetSuggestsVacancyPositionsAsync_WithNullSearchStringParam_ThrowException()
        {
            var action = async () => { await _context.HeadHunter.Suggests.GetSuggestsVacancyPositionsAsync(null); };

            await Assert.ThrowsAsync<ArgumentNullException>(action);
        }

        [Fact]
        public async Task GetSuggestsVacancyPositionsAsync_WithEmptySearchStringParam_ThrowException()
        {
            var action = async () => { await _context.HeadHunter.Suggests.GetSuggestsVacancyPositionsAsync(""); };

            await Assert.ThrowsAsync<ArgumentNullException>(action);
        }

        [Fact]
        public async Task GetSuggestsVacancyPositionsAsync_WhenSearchStringParamHaveLengthLessThanMinLengthSearchString_ThrowException()
        {
            var action = async () => { await _context.HeadHunter.Suggests.GetSuggestsVacancyPositionsAsync("Пр"); };

            await Assert.ThrowsAsync<ArgumentOutOfRangeException>(action);
        }

        [Fact]
        public async Task GetSuggestsVacancyPositionsAsync_WithValidSearchStringParam_ReturnSuccessResponseWithNotEmptyResult()
        {
            var response = await _context.HeadHunter.Suggests.GetSuggestsVacancyPositionsAsync("Программист");
            var statusCode = response.Status.Code;

            Assert.NotNull(response);
            Assert.NotNull(response.Result);
            Assert.NotEmpty(response?.Result?.Items);
            Assert.Equal(HttpStatusCode.OK, statusCode);
        }

        [Fact]
        public async Task GetSuggestsVacancyKeyWordsAsync_WithNullSearchStringParam_ThrowException()
        {
            var action = async () => { await _context.HeadHunter.Suggests.GetSuggestsVacancyKeyWordsAsync(null); };

            await Assert.ThrowsAsync<ArgumentNullException>(action);
        }

        [Fact]
        public async Task GetSuggestsVacancyKeyWordsAsync_WithEmptySearchStringParam_ThrowException()
        {
            var action = async () => { await _context.HeadHunter.Suggests.GetSuggestsVacancyKeyWordsAsync(""); };

            await Assert.ThrowsAsync<ArgumentNullException>(action);
        }

        [Fact]
        public async Task GetSuggestsVacancyKeyWordsAsync_WhenSearchStringParamHaveLengthLessThanMinLengthSearchString_ThrowException()
        {
            var action = async () => { await _context.HeadHunter.Suggests.GetSuggestsVacancyKeyWordsAsync("Ju"); };

            await Assert.ThrowsAsync<ArgumentOutOfRangeException>(action);
        }

        [Fact]
        public async Task GetSuggestsVacancyKeyWordsAsync_WithValidSearchStringParam_ReturnSuccessResponseWithNotEmptyResult()
        {
            var response = await _context.HeadHunter.Suggests.GetSuggestsVacancyKeyWordsAsync("Junior");
            var statusCode = response.Status.Code;

            Assert.NotNull(response);
            Assert.NotNull(response.Result);
            Assert.NotEmpty(response?.Result?.Items);
            Assert.Equal(HttpStatusCode.OK, statusCode);
        }
    }
}
