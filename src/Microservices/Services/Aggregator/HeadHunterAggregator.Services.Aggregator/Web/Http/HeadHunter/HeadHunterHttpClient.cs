using HeadHunterAggregator.Infrastructure.Web.Http;

namespace HeadHunterAggregator.Services.Aggregator.Web.Http.HeadHunter
{
    public class HeadHunterHttpClient : BaseHttpClient
    {
        private readonly Dictionary<string, string> _headers = new Dictionary<string, string>()
        {
            { "accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp," +
                "image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9" },
            { "accept-encoding", "gzip, deflate, br" },
            { "accept-language", "ru,en;q=0.9" },
            { "cache-control", "max-age=0" },
            { "sec-ch-ua", "\"Chromium\";v=\"118\", \"YaBrowser\";v=\"23\", \"Not=A?Brand\";v=\"99\"" },
            { "sec-ch-ua-mobile", "?0" },
            { "sec-ch-ua-platform", "\"Windows\"" },
            { "sec-fetch-dest", "document" },
            { "sec-fetch-mode", "navigate" },
            { "sec-fetch-site", "none" },
            { "sec-fetch-user", "?1" },
            { "upgrade-insecure-requests", "1" },
            { "user-agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) " +
                "Chrome/118.0.5993.2470 YaBrowser/23.11.0.2470 Yowser/2.5 Safari/537.36" }
        };

        public HeadHunterHttpClient(Uri relativeUri) : base(new Uri(new Uri(HeadHunterRoutes.BaseUrl), 
            relativeUri)) 
        {
            UseHeaders(_headers);
        }
    }
}
