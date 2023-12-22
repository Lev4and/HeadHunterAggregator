using HeadHunterAggregator.Services.Aggregator.Web.Http.HeadHunter;

namespace HeadHunterAggregator.Services.Aggregator.Tests.Web.Http.HeadHunter
{
    public class VacanciesHttpClientTests
    {
        private readonly VacanciesHttpClient _httpClient;

        public VacanciesHttpClientTests()
        {
            _httpClient = new VacanciesHttpClient();
        }

        [Theory]
        [ClassData(typeof(VacanciesHttpClientTestsData.GetVacanciesInvalidParams))]
        public async Task GetVacanciesAsync_WithInvalidParams_ShouldThrowException(int page, int perPage,
            DateTime dateFrom, DateTime dateTo)
        {
            var action = async () => await _httpClient.GetVacanciesAsync(page, perPage, dateFrom, dateTo);

            await Assert.ThrowsAnyAsync<Exception>(action);
        }

        [Theory]
        [ClassData(typeof(VacanciesHttpClientTestsData.GetVacanciesValidParams))]
        public async Task GetVacanciesAsync_WithValidParams_ReturnNotEmptyResult(int page, int perPage,
            DateTime dateFrom, DateTime dateTo)
        {
            var response = await _httpClient.GetVacanciesAsync(page, perPage, dateFrom, dateTo);

            Assert.NotNull(response.Result);

            Assert.NotEmpty(response.Result.Items);
        }

        [Theory]
        [ClassData(typeof(VacanciesHttpClientTestsData.GetVacancyOutOfRangeIdParams))]
        public async Task GetVacancyAsync_WithOutOfRangeIdParam_ShouldThrowException(long id)
        {
            var action = async () => await _httpClient.GetVacancyAsync(id);

            await Assert.ThrowsAsync<ArgumentOutOfRangeException>(action);
        }

        [Theory]
        [ClassData(typeof(VacanciesHttpClientTestsData.GetVacancyNonExistentIdParams))]
        public async Task GetVacancyAsync_WithNonExistentIdParam_ReturnNullResult(long id)
        {
            var response = await _httpClient.GetVacancyAsync(id);

            Assert.Null(response.Result);
        }

        [Theory]
        [ClassData(typeof(VacanciesHttpClientTestsData.GetVacancyExistentIdParams))]
        public async Task GetVacancyAsync_WithExistentIdParam_ReturnNotNullResult(long id)
        {
            var response = await _httpClient.GetVacancyAsync(id);

            Assert.NotNull(response.Result);

            Assert.NotEmpty(response.Result.Id);
            Assert.NotEmpty(response.Result.Name);
        }
    }
}
