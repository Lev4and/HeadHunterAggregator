using Newtonsoft.Json;

namespace HeadHunter.HttpClients.HeadHunter.ResponseModels
{
    public class Currency
    {
        [JsonProperty("code")]
        public string? Code { get; set; }

        [JsonProperty("abbr")]
        public string? Abbr { get; set; }

        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("default")]
        public bool? Default { get; set; }

        [JsonProperty("rate")]
        public double? Rate { get; set; }

        [JsonProperty("in_use")]
        public bool? InUse { get; set; }
    }
}