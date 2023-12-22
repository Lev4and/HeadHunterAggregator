using Newtonsoft.Json;

namespace HeadHunterAggregator.Services.Aggregator.Web.Http.HeadHunter.DTOs
{
    public class InsiderInterviewDto
    {
        [JsonRequired]
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("title")]
        public string? Title { get; set; }

        [JsonRequired]
        [JsonProperty("url")]
        public string Url { get; set; }
    }
}
