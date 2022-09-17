using Newtonsoft.Json;

namespace HeadHunter.Models
{
    public class Industry
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("industries")]
        public List<Industry>? Industries { get; set; }
    }
}
