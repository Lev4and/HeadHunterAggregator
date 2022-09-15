using Newtonsoft.Json;

namespace HeadHunter.Models
{
    public class Employer
    {
        [JsonProperty("logo_urls")]
        public LogoUrls? LogoUrls { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("url")]
        public string? Url { get; set; }

        [JsonProperty("alternate_url")]
        public string? AlternateUrl { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("trusted")]
        public bool? Trusted { get; set; }

        [JsonProperty("blacklisted")]
        public bool? Blacklisted { get; set; }

        [JsonProperty("area")]
        public Area? Area { get; set; }

        [JsonProperty("branded_description")]
        public string? BrandedDescription { get; set; }

        [JsonProperty("description")]
        public string? Description { get; set; }

        [JsonProperty("industries")]
        public List<Industry> Industries { get; set; }

        [JsonProperty("insider_interviews")]
        public List<InsiderInterview> InsiderInterviews { get; set; }

        [JsonProperty("open_vacancies")]
        public int? OpenVacancies { get; set; }

        [JsonProperty("relations")]
        public List<object> Relations { get; set; }

        [JsonProperty("site_url")]
        public string? SiteUrl { get; set; }

        [JsonProperty("type")]
        public string? Type { get; set; }

        [JsonProperty("vacancies_url")]
        public string? VacanciesUrl { get; set; }

        [JsonProperty("text")]
        public string? Text { get; set; }
    }
}
