using Newtonsoft.Json;

namespace HeadHunterAggregator.Services.Vacancy.Web.Http.HeadHunter.DTOs
{
    public class VacancyPositionDto
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("text")]
        public string? Text { get; set; }

        [JsonProperty("professional_roles")]
        public IReadOnlyCollection<ProfessionalRoleDto>? ProfessionalRoles { get; set; }
    }
}
