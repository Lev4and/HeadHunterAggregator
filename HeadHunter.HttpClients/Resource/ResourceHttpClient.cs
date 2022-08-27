using HeadHunter.HttpClients.Common;

namespace HeadHunter.HttpClients.Resource
{
    public class ResourceHttpClient : BaseHttpClient
    {
        public ResourceHttpClient(string path) : base($"{ResourceRoutes.Protocol}://{ResourceRoutes.Domain}/{path}")
        {
            if (path == null)
            {
                throw new ArgumentNullException(nameof(path));
            }
        }
    }
}
