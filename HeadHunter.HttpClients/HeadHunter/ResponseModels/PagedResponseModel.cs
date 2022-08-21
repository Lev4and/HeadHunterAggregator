using Newtonsoft.Json;

namespace HeadHunter.HttpClients.HeadHunter.ResponseModels
{
    public class PagedResponseModel<T> : ItemsResponseModel<T>
    {
        [JsonProperty("page")]
        public int Page { get; }

        [JsonProperty("found")]
        public int Found { get;}

        [JsonProperty("per_page")]
        public int PerPage { get; }
    }
}
