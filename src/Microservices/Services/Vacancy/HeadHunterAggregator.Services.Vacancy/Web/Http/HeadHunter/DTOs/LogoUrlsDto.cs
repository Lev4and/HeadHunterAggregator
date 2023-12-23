using Newtonsoft.Json;

namespace HeadHunterAggregator.Services.Vacancy.Web.Http.HeadHunter.DTOs
{
    public class LogoUrlsDto
    {
        [JsonProperty("90")]
        public string? Small { get; set; }

        [JsonProperty("240")]
        public string? Normal { get; set; }

        [JsonProperty("original")]
        public string? Original { get; set; }
    }
}
