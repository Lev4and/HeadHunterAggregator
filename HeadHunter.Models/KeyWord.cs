using Newtonsoft.Json;

namespace HeadHunter.Models
{
    public class KeyWord
    {
        [JsonProperty("text")]
        public string Text { get; set; }
    }
}
