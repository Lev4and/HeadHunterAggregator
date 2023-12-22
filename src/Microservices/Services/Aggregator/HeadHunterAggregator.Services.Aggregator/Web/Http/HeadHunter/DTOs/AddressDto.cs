using Newtonsoft.Json;

namespace HeadHunterAggregator.Services.Aggregator.Web.Http.HeadHunter.DTOs
{
    public class AddressDto
    {
        [JsonRequired]
        [JsonProperty("city")]
        public string City { get; set; }

        [JsonRequired]
        [JsonProperty("street")]
        public string Street { get; set; }

        [JsonRequired]
        [JsonProperty("building")]
        public string Building { get; set; }

        [JsonProperty("description")]
        public string? Description { get; set; }

        [JsonProperty("lat")]
        public double? Latitude { get; set; }

        [JsonProperty("lng")]
        public double? Longitude { get; set; }

        [JsonProperty("metro_stations")]
        public IReadOnlyCollection<MetroStationDto>? MetroStations { get; set; }
    }
}
