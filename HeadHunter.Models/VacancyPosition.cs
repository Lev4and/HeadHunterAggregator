using Newtonsoft.Json;

namespace HeadHunter.Models
{
    public class VacancyPosition
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("professional_roles")]
        public ProfessionalRole[] ProfessionalRoles { get; set; }
    }
}
