﻿using Newtonsoft.Json;

namespace HeadHunter.HttpClients.HeadHunter.ResponseModels
{
    public class Phone
    {
        [JsonProperty("country")]
        public string? Country { get; set; }

        [JsonProperty("city")]
        public string? City { get; set; }

        [JsonProperty("number")]
        public string? Number { get; set; }

        [JsonProperty("comment")]
        public object? Comment { get; set; }
    }
}
