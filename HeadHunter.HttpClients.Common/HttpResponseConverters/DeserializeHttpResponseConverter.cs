using HeadHunter.HttpClients.Common.Extensions;
using HeadHunter.Model.Common;

namespace HeadHunter.HttpClients.Common.HttpResponseConverters
{
    public class DeserializeHttpResponseConverter : IConvertibleHttpResponse
    {
        public IReadableHttpContent HttpContentReader { get; }

        public DeserializeHttpResponseConverter(IReadableHttpContent httpContentReader)
        {
            HttpContentReader = httpContentReader;
        }

        public async Task<ResponseModel<T>> ToResponseModelAsync<T>(HttpResponseMessage response)
        {
            var content = await HttpContentReader.ReadAsStringAsync(response.Content);
            var result = content.Deserialize<ResponseModel<T>>();

            return result;
        }
    }
}
