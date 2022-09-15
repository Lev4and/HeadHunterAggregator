using Newtonsoft.Json;

namespace HeadHunter.Models
{
    public class Language
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("level")]
        public Level? Level { get; set; }
    }
}
