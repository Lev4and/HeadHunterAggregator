using Newtonsoft.Json;

namespace HeadHunterAggregator.Services.Vacancy.Web.Http.HeadHunter.DTOs
{
    public class DriverLicenseTypeDto
    {
        [JsonProperty("id")]
        public string Id { get; set; }
    }
}
