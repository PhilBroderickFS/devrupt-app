using System.Collections.Generic;

namespace DevRupt.Core.Models
{
    public class ServiceItem
    {
        public Service Service { get; set; }
        public ServiceTotalAmount TotalAmount { get; set; }
        public List<ServiceDate> Dates { get; set; }
    }
}