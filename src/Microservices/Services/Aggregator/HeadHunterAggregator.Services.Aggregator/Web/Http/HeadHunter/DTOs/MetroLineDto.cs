using Newtonsoft.Json;

namespace HeadHunterAggregator.Services.Aggregator.Web.Http.HeadHunter.DTOs
{
    public class MetroLineDto
    {
        [JsonRequired]
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("hex_color")]
        public string? HexColor { get; set; }

        [JsonRequired]
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("area_id")]
        public string? AreaId { get; set; }

        [JsonProperty("area")]
        public AreaDto? Area { get; set; }

        [JsonProperty("stations")]
        public IReadOnlyCollection<MetroStationDto>? Stations { get; set; }
    }
}