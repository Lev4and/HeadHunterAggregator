using System.Net;

namespace HeadHunterAggregator.Infrastructure.Web.Http.ResponseMapers
{
    public interface IResponseMaper
    {
        ResponseModel<TResult> Map<TResult>(string? responseContent, 
            HttpStatusCode statusCode = HttpStatusCode.OK);
    }
}
