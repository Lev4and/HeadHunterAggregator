namespace HeadHunter.Models
{
    public class NegotiationsState
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}