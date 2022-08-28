using HeadHunter.HttpClients.Common.Extensions;
using HeadHunter.Model.Common;

namespace HeadHunter.HttpClients.Common.HttpResponseConverters
{
    public class DefaultHttpResponseConverter : IConvertibleHttpResponse
    {
        public IReadableHttpContent HttpContentReader { get; }

        public DefaultHttpResponseConverter(IReadableHttpContent httpContentReader)
        {
            HttpContentReader = httpContentReader;
        }

        public async Task<ResponseModel<T>> ToResponseModelAsync<T>(HttpResponseMessage response)
        {
            var content = await HttpContentReader.ReadAsStringAsync(response.Content);
            var result = content.Deserialize<T>();
            var code = response.StatusCode;

            return new ResponseModel<T>(result, new ResponseStatus(code));
        }
    }
}
