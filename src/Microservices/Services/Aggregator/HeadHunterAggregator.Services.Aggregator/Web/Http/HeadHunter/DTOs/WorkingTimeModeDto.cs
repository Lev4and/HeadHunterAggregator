﻿using Newtonsoft.Json;

namespace HeadHunterAggregator.Services.Aggregator.Web.Http.HeadHunter.DTOs
{
    public class WorkingTimeModeDto
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}