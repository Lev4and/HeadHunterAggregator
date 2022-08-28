using HeadHunter.HttpClients.Common;
using HeadHunter.HttpClients.Common.HttpContentReaders;
using HeadHunter.HttpClients.Common.HttpResponseConverters;

namespace HeadHunter.HttpClients.Resource
{
    public class ResourceHttpClient : BaseHttpClient
    {
        public ResourceHttpClient(string path) : base($"{ResourceRoutes.Protocol}://{ResourceRoutes.Domain}/{path}",
            new DeserializeHttpResponseConverter(new DefaultHttpContentReader()))
        {
            if (path == null)
            {
                throw new ArgumentNullException(nameof(path));
            }
        }
    }
}
