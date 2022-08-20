using Newtonsoft.Json;

namespace HeadHunter.Models
{
    public class City
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("lines")]
        public List<MetroLine> Lines { get; set; }
    }
}
