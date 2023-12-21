using Newtonsoft.Json;
using System.Net;

namespace HeadHunterAggregator.Infrastructure.Web.Http.ResponseMapers
{
    public class WrappedJsonResponseMaper : IResponseMaper
    {
        public ResponseModel<TResult> Map<TResult>(string? responseContent, 
            HttpStatusCode statusCode = HttpStatusCode.OK)
        {
            if (responseContent == null) throw new ArgumentNullException(nameof(responseContent));

            return JsonConvert.DeserializeObject<ResponseModel<TResult>>(responseContent);
        }
    }
}
