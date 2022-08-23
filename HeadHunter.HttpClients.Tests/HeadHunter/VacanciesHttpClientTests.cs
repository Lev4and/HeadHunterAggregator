using System.Net;

namespace HeadHunter.HttpClients.Tests.HeadHunter
{
    public class VacanciesHttpClientTests
    {
        private readonly HttpContext _context;

        public VacanciesHttpClientTests()
        {
            _context = new HttpContext();
        }

        [Fact]
        public async Task GetVacanciesAsync_WithPerPageParamLessOne_ThrowException()
        {
            var action = async () => { await _context.HeadHunter.Vacancies.GetVacanciesAsync(100, 0, DateTime.UtcNow, DateTime.UtcNow); };

            await Assert.ThrowsAsync<ArgumentOutOfRangeException>(action);
        }

        [Fact]
        public async Task GetVacanciesAsync_WithPerPageParamGreaterOneHundred_ThrowException()
        {
            var action = async () => { await _context.HeadHunter.Vacancies.GetVacanciesAsync(100, 101, DateTime.UtcNow, DateTime.UtcNow); };

            await Assert.ThrowsAsync<ArgumentOutOfRangeException>(action);
        }

        [Fact]
        public async Task GetVacanciesAsync_WithPageParamLessOne_ThrowException()
        {
            var action = async () => { await _context.HeadHunter.Vacancies.GetVacanciesAsync(0, 100, DateTime.UtcNow, DateTime.UtcNow); };

            await Assert.ThrowsAsync<ArgumentOutOfRangeException>(action);
        }

        [Fact]
        public async Task GetVacanciesAsync_WhenOffsetExceedsOrEqualTwoThousand_ThrowException()
        {
            var action = async () => { await _context.HeadHunter.Vacancies.GetVacanciesAsync(20, 100, DateTime.UtcNow, DateTime.UtcNow); };

            await Assert.ThrowsAsync<ArgumentOutOfRangeException>(action);
        }

        [Fact]
        public async Task GetVacanciesAsync_WhenDateFromParamGreaterThanDateToParam_ThrowException()
        {
            var action = async () => { await _context.HeadHunter.Vacancies.GetVacanciesAsync(20, 100, DateTime.UtcNow.AddHours(1), DateTime.UtcNow); };

            await Assert.ThrowsAsync<ArgumentOutOfRangeException>(action);
        }

        [Fact]
        public async Task GetVacanciesAsync_WhenDateToParamLessThanDateFromParam_ThrowException()
        {
            var action = async () => { await _context.HeadHunter.Vacancies.GetVacanciesAsync(20, 100, DateTime.UtcNow, DateTime.UtcNow.AddHours(-1)); };

            await Assert.ThrowsAsync<ArgumentOutOfRangeException>(action);
        }

        [Fact]
        public async Task GetVacanciesAsync_WhenValidParams_ReturnSuccessResponseWithNotEmptyResult()
        {
            var response = await _context.HeadHunter.Vacancies.GetVacanciesAsync(1, 100, DateTime.UtcNow.AddHours(-1), DateTime.UtcNow);
            var statusCode = response.Status.Code;

            Assert.NotNull(response);
            Assert.NotNull(response.Result);
            Assert.Equal(1, response?.Result?.Page);
            Assert.Equal(100, response?.Result?.PerPage);
            Assert.True(response?.Result?.Found > 0);
            Assert.NotEmpty(response?.Result?.Items);
            Assert.Equal(HttpStatusCode.OK, statusCode);
        }

        [Fact]
        public async Task GetVacancyAsync_WithInvalidIdParam_ThrowException()
        {
            var action = async () => { await _context.HeadHunter.Vacancies.GetVacancyAsync(-1); };

            await Assert.ThrowsAsync<ArgumentOutOfRangeException>(action);
        }

        [Fact]
        public async Task GetVacancyAsync_WithNotExistsIdParam_ReturnNotFoundResponseWithNotNullResult()
        {
            var response = await _context.HeadHunter.Vacancies.GetVacancyAsync(1);
            var statusCode = response.Status.Code;

            Assert.NotNull(response);
            Assert.NotNull(response.Result);
            Assert.Equal(HttpStatusCode.NotFound, statusCode);
        }

        [Fact]
        public async Task GetVacancyAsync_WithValidIdParam_ReturnSuccessResponseWithNotNullResult()
        {
            var response = await _context.HeadHunter.Vacancies.GetVacancyAsync(68666518);
            var statusCode = response.Status.Code;

            Assert.NotNull(response);
            Assert.NotNull(response.Result);
            Assert.Equal(HttpStatusCode.OK, statusCode);
        }
    }
}
