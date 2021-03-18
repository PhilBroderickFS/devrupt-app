using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DevRupt.Core.Models
{
    public class Reservation
    {
        [Key]
        public string Id { get; set; }

        public string BookingId { get; set; }
        
        public DateTimeOffset Arrival { get; set; }
        
        public DateTimeOffset Departure { get; set; }

        public PrimaryGuest PrimaryGuest { get; set; }
        
        public string RatePlanId { get; set; }
        public RatePlan RatePlan { get; set; }

        public int Adults { get; set; }
        
        public List<ServiceItem> Services { get; set; }
        
        public List<Folio> Folios { get; set; }
    }
}