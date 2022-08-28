using HeadHunter.HttpClients.Common.Extensions;
using HeadHunter.HttpClients.Common.HttpContentReaders;
using HeadHunter.HttpClients.Common.HttpResponseConverters;
using HeadHunter.Model.Common;
using System.Net;

namespace HeadHunter.HttpClients.Common
{
    public class BaseHttpClient : HttpClient
    {
        public IConvertibleHttpResponse ResponseConverter { get; }

        public BaseHttpClient(): base(new HttpClientHandlerBuilder().WithAllowAutoRedirect().WithAutomaticDecompression()
            .UseCertificateCustomValidation().Build())
        {
            ResponseConverter = new DefaultHttpResponseConverter(new DefaultHttpContentReader());
        }

        public BaseHttpClient(IConvertibleHttpResponse responseConverter) : base(new HttpClientHandlerBuilder().WithAllowAutoRedirect().WithAutomaticDecompression()
            .UseCertificateCustomValidation().Build())
        {
            ResponseConverter = responseConverter;
        }

        public BaseHttpClient(string uri) : base(new HttpClientHandlerBuilder().WithAllowAutoRedirect().WithAutomaticDecompression()
            .UseCertificateCustomValidation().Build())
        {
            if (string.IsNullOrEmpty(uri))
            {
                throw new ArgumentNullException(nameof(uri));
            }

            BaseAddress = new Uri(uri);
            ResponseConverter = new DefaultHttpResponseConverter(new DefaultHttpContentReader());
        }

        public BaseHttpClient(string uri, IConvertibleHttpResponse responseConverter) : base(new HttpClientHandlerBuilder().WithAllowAutoRedirect().WithAutomaticDecompression()
            .UseCertificateCustomValidation().Build())
        {
            if (string.IsNullOrEmpty(uri))
            {
                throw new ArgumentNullException(nameof(uri));
            }

            BaseAddress = new Uri(uri);
            ResponseConverter = responseConverter;
        }

        public async Task<ResponseModel<string>> Get(string query)
        {
            if (query == null)
            {
                throw new ArgumentNullException(nameof(query));
            }

            return await (await GetAsync(query)).GetResponseModel();
        }

        public async Task<ResponseModel<T>> Get<T>(string query)
        {
            if (query == null)
            {
                throw new ArgumentNullException(nameof(query));
            }

            return await ResponseConverter.ToResponseModelAsync<T>(await GetAsync(query));
        }

        public async Task<ResponseModel<T>> Post<T>(string query, object content)
        {
            if (query == null)
            {
                throw new ArgumentNullException(nameof(query));
            }

            return await ResponseConverter.ToResponseModelAsync<T>(await PostAsync(query, content.ToStringContent()));
        }

        public async Task<ResponseModel<T>> Put<T>(string query, object content)
        {
            if (query == null)
            {
                throw new ArgumentNullException(nameof(query));
            }

            return await ResponseConverter.ToResponseModelAsync<T>(await PutAsync(query, content.ToStringContent()));
        }

        public async Task<ResponseModel<T>> Delete<T>(string query)
        {
            if (query == null)
            {
                throw new ArgumentNullException(nameof(query));
            }

            return await ResponseConverter.ToResponseModelAsync<T>(await DeleteAsync(query));
        }

        public void UseHeaders(Dictionary<string, string> headers)
        {
            if (headers == null)
            {
                throw new ArgumentNullException(nameof(headers));
            }

            DefaultRequestHeaders.Clear();

            foreach (var header in headers)
            {
                DefaultRequestHeaders.Add(header.Key, header.Value);
            }
        }
    }
}
