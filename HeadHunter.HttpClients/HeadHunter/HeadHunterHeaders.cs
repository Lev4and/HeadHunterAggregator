namespace HeadHunter.HttpClients.HeadHunter
{
    public class HeadHunterHeaders
    {
        public static Dictionary<string, string> DefaultHeaders => new Dictionary<string, string>()
        {
            { "accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9" },
            { "accept-encoding", "gzip, deflate, br" },
            { "accept-language", "ru,en;q=0.9" },
            { "cache-control", "max-age=0" },
            { "sec-ch-ua", "\" Not A;Brand\";v=\"99\", \"Chromium\";v=\"102\", \"Yandex\";v=\"22\"" },
            { "sec-ch-ua-mobile", "?0" },
            { "sec-ch-ua-platform", "\"Windows\"" },
            { "sec-fetch-dest", "document" },
            { "sec-fetch-mode", "navigate" },
            { "sec-fetch-site", "none" },
            { "sec-fetch-user", "?1" },
            { "upgrade-insecure-requests", "1" },
            { "user-agent", "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/102.0.5005.167 YaBrowser/22.7.3.821 Yowser/2.5 Safari/537.36" }
        };
    }
}
