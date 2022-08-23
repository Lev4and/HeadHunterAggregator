using HeadHunter.HttpClients.HeadHunter;

namespace HeadHunter.HttpClients.Tests.HeadHunter
{
    public class HeadHunterHttpClientTests
    {
        [Fact]
        public void Initialization_WithInvalidPathParam_ThrowException()
        {
            var action = () => { new HeadHunterHttpClient(null); };

            Assert.Throws<ArgumentNullException>(action);
        }

        [Fact]
        public void Initialization_WithValidPathParam_InitializeHttpClient()
        {
            var httpClient = new HeadHunterHttpClient("vacancies");

            Assert.NotNull(httpClient);
        }
    }
}
