using Newtonsoft.Json;
using System.Net;

namespace HeadHunterAggregator.Infrastructure.Web.Http.ResponseMapers
{
    public class JsonResponseMaper : IResponseMaper
    {
        public ResponseModel<TResult> Map<TResult>(string? responseContent, 
            HttpStatusCode statusCode = HttpStatusCode.OK)
        {
            if (responseContent == null) throw new ArgumentNullException(nameof(responseContent));

            return new ResponseModel<TResult>(JsonConvert.DeserializeObject<TResult>(responseContent), 
                statusCode);
        }
    }
}
