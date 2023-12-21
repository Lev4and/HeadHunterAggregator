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
        [ClassData(typeof(EmployersHttpClientTestsData.OutOfRangeIdParams))]
        public async Task GetEmployerAsync_WithOutOfRangeIdParam_ShouldThrowException(long id)
        {
            var action = async () => await _httpClient.GetEmployerAsync(id);

            await Assert.ThrowsAsync<ArgumentOutOfRangeException>(action);
        }
    }
}
