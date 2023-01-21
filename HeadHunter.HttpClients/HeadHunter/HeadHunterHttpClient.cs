using HeadHunter.HttpClients.Core;

namespace HeadHunter.HttpClients.HeadHunter
{
    public class HeadHunterHttpClient : BaseHttpClient
    {
        public HeadHunterHttpClient(string path) : base($"{HeadHunterRoutes.Protocol}://{HeadHunterRoutes.Domain}/{path}")
        {
            if (path == null) throw new ArgumentNullException(nameof(path));

            UseHeaders(HeadHunterHeaders.DefaultHeaders);
        }
    }
}
