using Newtonsoft.Json;

namespace HeadHunter.HttpClients.HeadHunter.ResponseModels
{
    public class ItemsResponseModel<T>
    {
        [JsonProperty("items")]
        public T[] Items { get; }
    }
}
