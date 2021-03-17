using Newtonsoft.Json;

namespace DevRupt.App.Models
{
    public class Reservation
    {
        [JsonProperty("access_token")]
        public string Id { get; set; }
        [JsonProperty("access_token")]
        public string BookingId { get; set; }
        [JsonProperty("access_token")]
        public PrimaryGuest PrimaryGuest { get; set; }
        [JsonProperty("access_token")]
        public int NumberOfAdult { get; set; }
        [JsonProperty("access_token")]
        public RatePlan RatePlan { get; set; }
    }
}
