﻿using Newtonsoft.Json;

namespace HeadHunter.HttpClients.HeadHunter.ResponseModels
{
    public class VacancyPosition
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("text")]
        public string? Text { get; set; }

        [JsonProperty("professional_roles")]
        public List<ProfessionalRole>? ProfessionalRoles { get; set; }
    }
}
