using Newtonsoft.Json;

namespace HeadHunterAggregator.Services.Aggregator.Web.Http.HeadHunter.DTOs
{
    public class KeySkillDto
    {
        [JsonProperty("id")]
        public string? Id { get; set; }

        [JsonProperty("text")]
        public string? Text { get; set; }

        [JsonRequired]
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
