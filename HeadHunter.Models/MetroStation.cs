using Newtonsoft.Json;

namespace HeadHunter.Models
{
    public class MetroStation
    {
        [JsonProperty("id")]
        public string? Id { get; set; }

        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("order")]
        public int? Order { get; set; }

        [JsonProperty("station_id")]
        public string? StationId { get; set; }

        [JsonProperty("station_name")]
        public string? StationName { get; set; }

        [JsonProperty("line_id")]
        public string? LineId { get; set; }

        [JsonProperty("line_name")]
        public string? LineName { get; set; }

        [JsonProperty("lat")]
        public double? Lat { get; set; }

        [JsonProperty("lng")]
        public double? Lng { get; set; }
    }
}
