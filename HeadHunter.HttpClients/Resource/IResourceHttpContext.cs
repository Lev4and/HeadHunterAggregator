using HeadHunter.HttpClients.Resource.Import;

namespace HeadHunter.HttpClients.Resource
{
    public interface IResourceHttpContext
    {
        IImportHttpContext Import { get; }
    }
}
