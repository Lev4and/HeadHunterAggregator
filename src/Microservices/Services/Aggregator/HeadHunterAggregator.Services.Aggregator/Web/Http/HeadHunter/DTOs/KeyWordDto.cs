using Newtonsoft.Json;

namespace HeadHunterAggregator.Services.Aggregator.Web.Http.HeadHunter.DTOs
{
    public class KeyWordDto
    {
        [JsonProperty("text")]
        public string Text { get; set; }
    }
}
