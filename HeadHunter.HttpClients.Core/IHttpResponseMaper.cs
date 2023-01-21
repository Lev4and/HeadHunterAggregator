using HeadHunter.HttpClients.Core.ResponseModels;
using System.Net;

namespace HeadHunter.HttpClients.Core
{
    public interface IHttpResponseMaper
    {
        ResponseModel<TResult> Map<TResult>(string? responseContent, HttpStatusCode statusCode = HttpStatusCode.OK);
    }
}
