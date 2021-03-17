using Newtonsoft.Json;

namespace DevRupt.App.Models
{
    public class Address
    {
        [JsonProperty("addressLine")]
        public string AddressLine { get; set; }
        [JsonProperty("postalCode")]
        public string PostalCode { get; set; }
        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("countryCode")]
        public string CountryCode { get; set; }
    }
}