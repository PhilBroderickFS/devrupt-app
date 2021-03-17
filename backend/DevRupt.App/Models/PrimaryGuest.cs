using Newtonsoft.Json;
using System;

namespace DevRupt.App.Models
{
    public class PrimaryGuest
    {
        [JsonProperty("access_token")]
        public string FirstName { get; set; }
        [JsonProperty("access_token")]
        public string LastName { get; set; }
        [JsonProperty("access_token")]
        public string Email { get; set; }
        [JsonProperty("access_token")]
        public string PhoneNumber { get; set; }
        [JsonProperty("access_token")]
        public Address Address { get; set; }
        [JsonProperty("access_token")]
        public string NationalityCountryCode { get; set; }
        [JsonProperty("access_token")]
        public DateTime BirthDate{ get; set; }
        [JsonProperty("access_token")]
        public string Gender { get; set; }
        [JsonProperty("access_token")]
        public string BirthPlace { get; set; }
        [JsonProperty("access_token")]
        public string PreferredLanguage { get; set; }


    }
}