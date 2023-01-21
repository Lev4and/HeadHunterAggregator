﻿using Newtonsoft.Json;

namespace HeadHunter.HttpClients.HeadHunter.ResponseModels
{
    public class PagedResponseModel<TData> : ItemsResponseModel<TData>
    {
        [JsonProperty("page")]
        public int Page { get; set; }

        [JsonProperty("found")]
        public int Found { get; set; }

        [JsonProperty("per_page")]
        public int PerPage { get; set; }
    }
}
