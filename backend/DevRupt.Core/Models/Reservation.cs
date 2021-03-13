using System;

namespace DevRupt.Core.Models
{
    public class Reservation
    {
        public string Id { get; set; }

        public string BookingId { get; set; }
        
        public DateTimeOffset Arrival { get; set; }
        
        public DateTimeOffset Departure { get; set; }

        public PrimaryGuest PrimaryGuest { get; set; }

        public int Adults { get; set; }
    }
}