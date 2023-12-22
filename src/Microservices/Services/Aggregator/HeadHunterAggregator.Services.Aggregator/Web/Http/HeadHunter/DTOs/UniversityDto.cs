using Newtonsoft.Json;

namespace HeadHunterAggregator.Services.Aggregator.Web.Http.HeadHunter.DTOs
{
    public class UniversityDto
    {
        [JsonRequired]
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("acronym")]
        public string? Acronym { get; set; }

        [JsonProperty("text")]
        public string? Text { get; set; }

        [JsonProperty("synonyms")]
        public string? Synonyms { get; set; }

        [JsonProperty("area")]
        public AreaDto? Area { get; set; }
    }
}
