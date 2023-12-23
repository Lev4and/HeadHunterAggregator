using Newtonsoft.Json;

namespace HeadHunterAggregator.Services.Vacancy.Web.Http.HeadHunter.DTOs
{
    public class PagedResponseModelDto<TData> : ItemsResponseModelDto<TData>
    {
        [JsonProperty("page")]
        public int Page { get; set; }

        [JsonProperty("found")]
        public int Found { get; set; }

        [JsonProperty("per_page")]
        public int PerPage { get; set; }
    }
}
