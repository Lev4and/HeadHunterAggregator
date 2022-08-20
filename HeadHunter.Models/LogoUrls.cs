using Newtonsoft.Json;

namespace HeadHunter.Models
{
    public class LogoUrls
    {
        [JsonProperty("90")]
        public string _90 { get; set; }

        [JsonProperty("240")]
        public string _240 { get; set; }

        [JsonProperty("original")]
        public string Original { get; set; }
    }
}
