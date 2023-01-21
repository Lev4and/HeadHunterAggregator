using HeadHunter.HttpClients.HeadHunter;
using HeadHunter.HttpClients.Resource;

namespace HeadHunter.HttpClients
{
    public class HttpContext : IHttpContext
    {
        public IHeadHunterHttpContext HeadHunter => new HeadHunterHttpContext();

        public IResourceHttpContext Resource => new ResourceHttpContext();
    }
}
