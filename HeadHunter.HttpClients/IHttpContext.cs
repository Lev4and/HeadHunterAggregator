using HeadHunter.HttpClients.HeadHunter;
using HeadHunter.HttpClients.Resource;

namespace HeadHunter.HttpClients
{
    public interface IHttpContext
    {
        IHeadHunterHttpContext HeadHunter { get; }

        IResourceHttpContext Resource { get; }
    }
}
