using Newtonsoft.Json;

namespace HeadHunter.Models
{
    public class Salary
    {
        [JsonProperty("to")]
        public object To { get; set; }

        [JsonProperty("from")]
        public int From { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("gross")]
        public bool Gross { get; set; }
    }
}
