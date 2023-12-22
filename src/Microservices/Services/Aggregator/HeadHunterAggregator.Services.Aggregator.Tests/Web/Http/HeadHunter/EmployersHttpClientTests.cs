using HeadHunterAggregator.Services.Aggregator.Web.Http.HeadHunter;

namespace HeadHunterAggregator.Services.Aggregator.Tests.Web.Http.HeadHunter
{
    public class EmployersHttpClientTests
    {
        private readonly EmployersHttpClient _httpClient;

        public EmployersHttpClientTests()
        {
            _httpClient = new EmployersHttpClient();
        }

        [Theory]
        [ClassData(typeof(EmployersHttpClientTestsData.GetEmployerOutOfRangeIdParams))]
        public async Task GetEmployerAsync_WithOutOfRangeIdParam_ShouldThrowException(long id)
        {
            var action = async () => await _httpClient.GetEmployerAsync(id);

            await Assert.ThrowsAsync<ArgumentOutOfRangeException>(action);
        }

        [Theory]
        [ClassData(typeof(EmployersHttpClientTestsData.GetEmployerNonExistentIdParams))]
        public async Task GetEmployerAsync_WithNonExistentIdParam_ReturnNullResult(long id)
        {
            var response = await _httpClient.GetEmployerAsync(id);

            Assert.Null(response.Result);
        }

        [Theory]
        [ClassData(typeof(EmployersHttpClientTestsData.GetEmployerExistentIdParams))]
        public async Task GetEmployerAsync_WithExistentIdParam_ReturnNotNullResult(long id)
        {
            var response = await _httpClient.GetEmployerAsync(id);

            Assert.NotNull(response.Result);

            Assert.NotEmpty(response.Result.Id);
            Assert.NotEmpty(response.Result.Name);
        }
    }
}
