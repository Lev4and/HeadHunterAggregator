using Newtonsoft.Json;

namespace HeadHunter.Models
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
