﻿using Newtonsoft.Json;

namespace HeadHunterAggregator.Services.Aggregator.Web.Http.HeadHunter.DTOs
{
    public class VacancyNotProlongedReasonDto
    {
        [JsonRequired]
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonRequired]
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}