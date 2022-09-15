using Newtonsoft.Json;

namespace HeadHunter.Models
{
    public class Country
    {
        [JsonProperty("url")]
        public string? Url { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
