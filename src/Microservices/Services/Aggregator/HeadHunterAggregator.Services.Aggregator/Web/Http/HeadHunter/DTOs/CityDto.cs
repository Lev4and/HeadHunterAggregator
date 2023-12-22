using Newtonsoft.Json;

namespace HeadHunterAggregator.Services.Aggregator.Web.Http.HeadHunter.DTOs
{
    public class CityDto
    {
        [JsonRequired]
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonRequired]
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("url")]
        public string? Url { get; set; }

        [JsonProperty("lines")]
        public IReadOnlyCollection<MetroLineDto>? Lines { get; set; }
    }
}
