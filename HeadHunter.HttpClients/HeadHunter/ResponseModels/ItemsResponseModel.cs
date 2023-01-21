using Newtonsoft.Json;

namespace HeadHunter.HttpClients.HeadHunter.ResponseModels
{
    public class ItemsResponseModel<TData>
    {
        [JsonProperty("items")]
        public TData[] Items { get; set; }
    }
}
