using Newtonsoft.Json;

namespace HeadHunter.HttpClients.HeadHunter.ResponseModels
{
    public class KeyWord
    {
        [JsonProperty("text")]
        public string Text { get; set; }
    }
}
