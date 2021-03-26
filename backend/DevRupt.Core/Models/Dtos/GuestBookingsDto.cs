using System;
using System.Collections.Generic;

namespace DevRupt.Core.Models.Dtos
{
    public class GuestBookingsDto
    {
        public int TotalBooked => Guests.Count;

        public DateTime Date { get; set; }

        public List<GuestDto> Guests { get; set; }
    }
}