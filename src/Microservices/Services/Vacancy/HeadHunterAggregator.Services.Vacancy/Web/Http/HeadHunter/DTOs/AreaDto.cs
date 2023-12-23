using Newtonsoft.Json;

namespace HeadHunterAggregator.Services.Vacancy.Web.Http.HeadHunter.DTOs
{
    public class AreaDto
    {
        [JsonProperty("url")]
        public string? Url { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("parent_id")]
        public string? ParentId { get; set; }

        [JsonProperty("text")]
        public string? Text { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("areas")]
        public IReadOnlyCollection<AreaDto>? Areas { get; set; }
    }
}
