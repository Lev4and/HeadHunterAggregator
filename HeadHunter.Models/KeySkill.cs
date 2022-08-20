using Newtonsoft.Json;

namespace HeadHunter.Models
{
    public class KeySkill
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
