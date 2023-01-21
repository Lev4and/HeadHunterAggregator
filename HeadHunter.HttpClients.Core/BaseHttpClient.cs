using HeadHunter.HttpClients.Core.Builders;
using HeadHunter.HttpClients.Core.Extensions;
using HeadHunter.HttpClients.Core.HttpRequestHandlers;
using HeadHunter.HttpClients.Core.ResponseModels;

namespace HeadHunter.HttpClients.Core
{
    public class BaseHttpClient : HttpClient
    {
        protected virtual IHttpRequestHandler HttpRequestHandler => new BaseHttpRequestHandler();

        public BaseHttpClient() : base(new HttpClientHandlerBuilder().WithAllowAutoRedirect()
            .WithAutomaticDecompression().UseCertificateCustomValidation().UseSslProtocols().Build())
        {

        }

        public BaseHttpClient(string uri) : base(new HttpClientHandlerBuilder().WithAllowAutoRedirect()
            .WithAutomaticDecompression().UseCertificateCustomValidation().UseSslProtocols().Build())
        {
            if (string.IsNullOrEmpty(uri)) throw new ArgumentNullException(nameof(uri));

            BaseAddress = new Uri(uri);
        }

        public async Task<ResponseModel<TResult>> GetAsync<TResult>(string uri, 
            CancellationToken cancellationToken = default)
        {
            if (uri == null) throw new ArgumentNullException(nameof(uri));

            return await HttpRequestHandler.HandleAsync<TResult>(() => GetAsync(uri, cancellationToken));
        }

        public async Task<ResponseModel<TResult>> PostAsync<TResult>(string uri, object content, 
            CancellationToken cancellationToken = default)
        {
            if (uri == null) throw new ArgumentNullException(nameof(uri));

            return await HttpRequestHandler.HandleAsync<TResult>(() => PostAsync(uri, content.ToStringContent(), 
                cancellationToken));
        }

        public async Task<ResponseModel<TResult>> PutAsync<TResult>(string uri, object content, 
            CancellationToken cancellationToken = default)
        {
            if (uri == null) throw new ArgumentNullException(nameof(uri));

            return await HttpRequestHandler.HandleAsync<TResult>(() => PutAsync(uri, content.ToStringContent(), 
                cancellationToken));
        }

        public async Task<ResponseModel<TResult>> DeleteAsync<TResult>(string uri, 
            CancellationToken cancellationToken = default)
        {
            if (uri == null) throw new ArgumentNullException(nameof(uri));

            return await HttpRequestHandler.HandleAsync<TResult>(() => DeleteAsync(uri, cancellationToken));
        }

        public void UseHeaders(Dictionary<string, string> headers)
        {
            if (headers == null) throw new ArgumentNullException(nameof(headers));

            DefaultRequestHeaders.Clear();

            foreach (var header in headers)
            {
                DefaultRequestHeaders.Add(header.Key, header.Value);
            }
        }

        public void OverrideHeaders(Dictionary<string, string> headers)
        {
            if (headers == null) throw new ArgumentNullException(nameof(headers));

            foreach (var header in headers)
            {
                DefaultRequestHeaders.Remove(header.Key);
                DefaultRequestHeaders.Add(header.Key, header.Value);
            }
        }
    }
}
