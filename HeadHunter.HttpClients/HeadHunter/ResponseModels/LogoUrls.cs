using Newtonsoft.Json;

namespace HeadHunter.HttpClients.HeadHunter.ResponseModels
{
    public class LogoUrls
    {
        [JsonProperty("90")]
        public string? Small { get; set; }

        [JsonProperty("240")]
        public string? Normal { get; set; }

        [JsonProperty("original")]
        public string? Original { get; set; }
    }
}
