using System;
using Newtonsoft.Json;

namespace DevRupt.Core.Models
{
    public class ServiceDate
    {
        public int Id { get; set; }
        
        [JsonProperty("serviceDate")]
        public DateTime Date { get; set; }

        public int Count { get; set; }
    }
}