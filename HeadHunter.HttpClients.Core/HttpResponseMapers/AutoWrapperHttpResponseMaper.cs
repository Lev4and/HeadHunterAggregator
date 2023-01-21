using HeadHunter.HttpClients.Core.ResponseModels;
using Newtonsoft.Json;
using System.Net;

namespace HeadHunter.HttpClients.Core.HttpResponseMapers
{
    public class AutoWrapperHttpResponseMaper : IHttpResponseMaper
    {
        public ResponseModel<TResult> Map<TResult>(string? responseContent, 
            HttpStatusCode statusCode = HttpStatusCode.OK)
        {
            if (responseContent == null) throw new ArgumentNullException(nameof(responseContent));

            return JsonConvert.DeserializeObject<ResponseModel<TResult>>(responseContent);
        }
    }
}
