using Newtonsoft.Json;

namespace HeadHunterAggregator.Services.Aggregator.Web.Http.HeadHunter.DTOs
{
    public class DriverLicenseTypeDto
    {
        [JsonRequired]
        [JsonProperty("id")]
        public string Id { get; set; }
    }
}
