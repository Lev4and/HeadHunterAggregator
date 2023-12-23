using Newtonsoft.Json;

namespace HeadHunterAggregator.Services.Vacancy.Web.Http.HeadHunter.DTOs
{
    public class NegotiationsOrderDto
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}