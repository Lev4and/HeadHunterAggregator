using Newtonsoft.Json;

namespace HeadHunter.Models
{
    public class Industry
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("parent_id")]
        public string? ParentId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("industries")]
        public Industry[] Industries { get; set; }
    }
}
