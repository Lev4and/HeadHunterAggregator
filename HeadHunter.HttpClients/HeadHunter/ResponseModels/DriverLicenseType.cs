using Newtonsoft.Json;

namespace HeadHunter.HttpClients.HeadHunter.ResponseModels
{
    public class DriverLicenseType
    {
        [JsonProperty("id")]
        public string Id { get; set; }
    }
}
