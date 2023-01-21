using HeadHunter.HttpClients.Core.HttpResponseMapers;
using HeadHunter.HttpClients.Core.HttpResponseReaders;
using HeadHunter.HttpClients.Core.ResponseModels;

namespace HeadHunter.HttpClients.Core.HttpRequestHandlers
{
    public class BaseHttpRequestHandler : IHttpRequestHandler
    {
        public virtual IHttpResponseMaper Maper => new JsonHttpResponseMaper();

        public virtual IHttpResponseReader Reader => new BaseHttpResponseReader();

        public async Task<ResponseModel<TResult>> HandleAsync<TResult>(Func<Task<HttpResponseMessage>> invokeFunc)
        {
            if (invokeFunc == null) throw new ArgumentNullException(nameof(invokeFunc));

            try
            {
                var response = await InvokeRequestAsync(invokeFunc);

                var responseContent = await ReadResponseAsync(response);

                return Maper.Map<TResult>(responseContent, response.StatusCode);
            }
            catch (Exception ex)
            {
                return new ResponseModel<TResult>(default, null, ex.Message, true, ex);
            }
        }

        private async Task<HttpResponseMessage> InvokeRequestAsync(Func<Task<HttpResponseMessage>> invokeFunc)
        {
            if (invokeFunc == null) throw new ArgumentNullException(nameof(invokeFunc));

            return await invokeFunc.Invoke();
        }

        private async Task<string?> ReadResponseAsync(HttpResponseMessage response)
        {
            if (response == null) throw new ArgumentNullException(nameof(response));

            return await Reader.ReadAsync(response);
        }
    }
}
