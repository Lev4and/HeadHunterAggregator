using Newtonsoft.Json;

namespace HeadHunter.Models
{
    public class University
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("acronym")]
        public string Acronym { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("synonyms")]
        public string Synonyms { get; set; }

        [JsonProperty("area")]
        public Area Area { get; set; }
    }
}
