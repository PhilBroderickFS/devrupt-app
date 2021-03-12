namespace net_core_API.Models
{
    public class Reservation
    {
        public string Id { get; set; }

        public string BookingId { get; set; }

        public PrimaryGuest PrimaryGuest { get; set; }

        public int NumberOfAdult { get; set; }

        public RatePlan RatePlan { get; set; }
    }
}
