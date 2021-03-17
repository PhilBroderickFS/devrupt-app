using Newtonsoft.Json;

namespace DevRupt.App.Models
{
    public class RatePlan
    {
        [JsonProperty("access_token")]
        public string Id { get; set; }
        [JsonProperty("access_token")]
        public string Code { get; set; }
        [JsonProperty("access_token")]
        public string Name { get; set; }
        [JsonProperty("access_token")]
        public string Description { get; set; }
        [JsonProperty("access_token")]
        public bool IsSubjectToCityTax { get; set; }
    }
}