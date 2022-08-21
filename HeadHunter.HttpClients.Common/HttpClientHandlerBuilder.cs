using System.Net;

namespace HeadHunter.HttpClients.Common
{
    public class HttpClientHandlerBuilder
    {
        private readonly HttpClientHandler _httpClientHandler = new HttpClientHandler();

        public HttpClientHandlerBuilder UseCertificateCustomValidation()
        {
            _httpClientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) =>
            {
                return true;
            };

            return this;
        }

        public HttpClientHandlerBuilder WithAllowAutoRedirect()
        {
            _httpClientHandler.AllowAutoRedirect = true;

            return this;
        }

        public HttpClientHandlerBuilder WithAutomaticDecompression()
        {
            _httpClientHandler.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate | DecompressionMethods.Brotli;

            return this;
        }

        public HttpClientHandler Build()
        {
            return _httpClientHandler;
        }
    }
}
