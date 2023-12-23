using Newtonsoft.Json;

namespace HeadHunterAggregator.Services.Vacancy.Web.Http.HeadHunter.DTOs
{
    public class SpecializationDto
    {
        [JsonProperty("profarea_id")]
        public string? ProfareaId { get; set; }

        [JsonProperty("profarea_name")]
        public string? ProfareaName { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("parent_id")]
        public string? ParentId { get; set; }

        [JsonProperty("text")]
        public string? Text { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("laboring")]
        public bool? Laboring { get; set; }

        [JsonProperty("specializations")]
        public IReadOnlyCollection<SpecializationDto>? Specializations { get; set; }
    }
}
