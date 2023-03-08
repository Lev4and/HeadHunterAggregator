using HeadHunter.HttpClients.Resource.Import;

namespace HeadHunter.HttpClients.Resource
{
    public class ResourceHttpContext : IResourceHttpContext
    {
        public IImportHttpContext Import => new ImportHttpContext();
    }
}
