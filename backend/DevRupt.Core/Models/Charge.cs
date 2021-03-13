using System;

namespace DevRupt.Core.Models
{
    public class Charge
    {
        public string Id { get; set; }
        public string ServiceType { get; set; }
        public DateTime ServiceDate { get; set; }
        public int Quantity { get; set; }
    }
}