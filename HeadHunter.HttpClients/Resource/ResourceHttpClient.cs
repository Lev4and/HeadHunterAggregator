using HeadHunter.HttpClients.Core;
using HeadHunter.HttpClients.Resource.HttpRequestHandlers;

namespace HeadHunter.HttpClients.Resource
{
    public class ResourceHttpClient : BaseHttpClient
    {
        protected override IHttpRequestHandler HttpRequestHandler => new ResourceHttpRequestHandler();

        public ResourceHttpClient(string path) : base($"{ResourceRoutes.Protocol}://{ResourceRoutes.Domain}/" +
            $"{Environment.GetEnvironmentVariable("BACKEND_URL_PATH") ?? "headhunter/resource"}/{path}")
        {
            if (path == null) throw new ArgumentNullException(nameof(path));
        }
    }
}
