using HeadHunter.HttpClients.HeadHunter;
using HeadHunter.HttpClients.Resource;

namespace HeadHunter.HttpClients
{
    public class HttpContext
    {
        public HeadHunterHttpContext HeadHunter => new HeadHunterHttpContext();

        public ResourceHttpContext Resource => new ResourceHttpContext();

        public HttpContext()
        {

        }
    }
}
