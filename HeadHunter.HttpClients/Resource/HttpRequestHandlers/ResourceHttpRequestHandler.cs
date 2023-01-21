using HeadHunter.HttpClients.Core.HttpRequestHandlers;
using HeadHunter.HttpClients.Core.HttpResponseMapers;
using HeadHunter.HttpClients.Core;

namespace HeadHunter.HttpClients.Resource.HttpRequestHandlers
{
    public class ResourceHttpRequestHandler : BaseHttpRequestHandler
    {
        public override IHttpResponseMaper Maper => new AutoWrapperHttpResponseMaper();
    }
}
