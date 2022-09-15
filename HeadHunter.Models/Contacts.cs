using Newtonsoft.Json;

namespace HeadHunter.Models
{
    public class Contacts
    {
        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("email")]
        public string? Email { get; set; }

        [JsonProperty("phones")]
        public List<Phone> Phones { get; set; }
    }
}
