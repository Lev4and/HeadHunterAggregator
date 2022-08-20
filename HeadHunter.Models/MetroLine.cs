using Newtonsoft.Json;

namespace HeadHunter.Models
{
    public class MetroLine
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("hex_color")]
        public string HexColor { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("stations")]
        public List<MetroStation> Stations { get; set; }
    }
}