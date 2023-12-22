using Newtonsoft.Json;

namespace HeadHunterAggregator.Services.Aggregator.Web.Http.HeadHunter.DTOs
{
    public class ContactsDto
    {
        [JsonRequired]
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonRequired]
        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("phones")]
        public IReadOnlyCollection<PhoneDto>? Phones { get; set; }
    }
}
