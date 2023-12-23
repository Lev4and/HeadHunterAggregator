using Newtonsoft.Json;

namespace HeadHunterAggregator.Services.Vacancy.Web.Http.HeadHunter.DTOs
{
    public class SalaryDto
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
