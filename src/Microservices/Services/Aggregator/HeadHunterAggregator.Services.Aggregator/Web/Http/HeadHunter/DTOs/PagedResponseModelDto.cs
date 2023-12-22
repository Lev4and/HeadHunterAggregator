using Newtonsoft.Json;

namespace HeadHunterAggregator.Services.Aggregator.Web.Http.HeadHunter.DTOs
{
    public class PagedResponseModelDto<TData> : ItemsResponseModelDto<TData>
    {
        [JsonRequired]
        [JsonProperty("page")]
        public int Page { get; set; }

        [JsonRequired]
        [JsonProperty("found")]
        public int Found { get; set; }

        [JsonRequired]
        [JsonProperty("per_page")]
        public int PerPage { get; set; }
    }
}
