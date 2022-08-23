using System.Net;

namespace HeadHunter.HttpClients.Common.Tests
{
    public class HttpClientHandlerBuilderTests
    {
        [Fact]
        public void UseCertificateCustomValidationThenBuild_ReturnNotNullHttpClientHandler()
        {
            var httpClientHandler = new HttpClientHandlerBuilder()
                .UseCertificateCustomValidation()
                .Build();

            Assert.NotNull(httpClientHandler);
            Assert.NotNull(httpClientHandler.ServerCertificateCustomValidationCallback);
        }

        [Fact]
        public void WithAllowAutoRedirect_ReturnNotNullHttpClientHandler()
        {
            var httpClientHandler = new HttpClientHandlerBuilder()
                .WithAllowAutoRedirect()
                .Build();

            Assert.NotNull(httpClientHandler);
            Assert.True(httpClientHandler.AllowAutoRedirect);
        }

        [Fact]
        public void WithAutomaticDecompression_ReturnNotNullHttpClientHandler()
        {
            var httpClientHandler = new HttpClientHandlerBuilder()
                .WithAutomaticDecompression()
                .Build();

            Assert.NotNull(httpClientHandler);
            Assert.NotNull(httpClientHandler?.AutomaticDecompression);
            Assert.Equal(DecompressionMethods.GZip | DecompressionMethods.Deflate | DecompressionMethods.Brotli, httpClientHandler?.AutomaticDecompression);
        }

        [Fact]
        public void Build_ReturnNotNullHttpClientHandler()
        {
            var httpClientHandler = new HttpClientHandlerBuilder().Build();

            Assert.NotNull(httpClientHandler); 
        }
    }
}
