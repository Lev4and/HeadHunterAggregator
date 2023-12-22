using Newtonsoft.Json;

namespace HeadHunterAggregator.Services.Aggregator.Web.Http.HeadHunter.DTOs
{
    public class ItemsResponseModelDto<TData>
    {
        [JsonRequired]
        [JsonProperty("items")]
        public IReadOnlyCollection<TData> Items { get; set; }
    }
}
