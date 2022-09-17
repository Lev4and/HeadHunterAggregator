using Newtonsoft.Json;

namespace HeadHunter.Models
{
    public class Address
    {
        [JsonProperty("city")]
        public string? City { get; set; }

        [JsonProperty("street")]
        public string? Street { get; set; }

        [JsonProperty("building")]
        public string? Building { get; set; }

        [JsonProperty("description")]
        public string? Description { get; set; }

        [JsonProperty("lat")]
        public double? Lat { get; set; }

        [JsonProperty("lng")]
        public double? Lng { get; set; }

        [JsonProperty("metro_stations")]
        public List<MetroStation>? MetroStations { get; set; }
    }
}
