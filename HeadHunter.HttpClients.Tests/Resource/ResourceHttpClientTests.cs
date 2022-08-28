using HeadHunter.HttpClients.Resource;

namespace HeadHunter.HttpClients.Tests.Resource
{
    public class ResourceHttpClientTests
    {
        [Fact]
        public void Initialization_WithInvalidPathParam_ThrowException()
        {
            var action = () => { new ResourceHttpClient(null); };

            Assert.Throws<ArgumentNullException>(action);
        }

        [Fact]
        public void Initialization_WithValidPathParam_InitializeHttpClient()
        {
            var httpClient = new ResourceHttpClient("vacancies");

            Assert.NotNull(httpClient);
        }
    }
}
