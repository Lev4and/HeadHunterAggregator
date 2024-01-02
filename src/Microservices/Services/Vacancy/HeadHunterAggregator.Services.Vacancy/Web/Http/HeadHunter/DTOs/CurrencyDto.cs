using Newtonsoft.Json;

namespace HeadHunterAggregator.Services.Vacancy.Web.Http.HeadHunter.DTOs
{
    public class CurrencyDto
    {
        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("abbr")]
        public string Abbr { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("default")]
        public bool Default { get; set; }

        [JsonProperty("rate")]
        public double Rate { get; set; }

        [JsonProperty("in_use")]
        public bool InUse { get; set; }
    }
}