using Newtonsoft.Json;

namespace HeadHunter.Models
{
    public class Experience
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
