using Newtonsoft.Json;

namespace HeadHunterAggregator.Services.Aggregator.Web.Http.HeadHunter.DTOs
{
    public class VacancyPositionDto
    {
        [JsonRequired]
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("text")]
        public string? Text { get; set; }

        [JsonProperty("professional_roles")]
        public IReadOnlyCollection<ProfessionalRoleDto>? ProfessionalRoles { get; set; }
    }
}
