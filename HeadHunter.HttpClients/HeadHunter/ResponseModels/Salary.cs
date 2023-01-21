using Newtonsoft.Json;

namespace HeadHunter.HttpClients.HeadHunter.ResponseModels
{
    public class Salary
    {
        [JsonProperty("to")]
        public decimal? To { get; set; }

        [JsonProperty("from")]
        public decimal? From { get; set; }

        [JsonProperty("currency")]
        public string? Currency { get; set; }

        [JsonProperty("gross")]
        public bool? Gross { get; set; }
    }
}
