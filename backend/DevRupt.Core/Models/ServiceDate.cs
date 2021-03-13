using System;
using Newtonsoft.Json;

namespace DevRupt.Core.Models
{
    public class ServiceDate
    {
        [JsonProperty("serviceDate")]
        public DateTime Date { get; set; }

        public int Count { get; set; }
    }
}