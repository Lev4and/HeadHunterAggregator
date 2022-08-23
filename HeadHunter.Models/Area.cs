using Newtonsoft.Json;

namespace HeadHunter.Models
{
    public class Area
    {
        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("parent_id")]
        public string? ParentId { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("areas")]
        public Area[] Areas { get; set; }
    }
}
