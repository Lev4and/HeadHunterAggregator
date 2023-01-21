using Newtonsoft.Json;

namespace HeadHunter.HttpClients.HeadHunter.ResponseModels
{
    public class MetroLine
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("hex_color")]
        public string? HexColor { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("area_id")]
        public string? AreaId { get; set; }

        [JsonProperty("area")]
        public Area? Area { get; set; }

        [JsonProperty("stations")]
        public List<MetroStation>? Stations { get; set; }
    }
}