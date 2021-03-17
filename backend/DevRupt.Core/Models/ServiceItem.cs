using System.Collections.Generic;

namespace DevRupt.Core.Models
{
    public class ServiceItem
    {
        public int Id { get; set; }
        public Service Service { get; set; }
        public ServiceTotalAmount TotalAmount { get; set; }
        public List<ServiceDate> Dates { get; set; }
    }
}