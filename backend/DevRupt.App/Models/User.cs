using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevRupt.App.Models
{
    public class User
    {
        [JsonProperty("access_token")]
        public int UserId { get; set; }
        [JsonProperty("access_token")]
        public string UserName { get; set; }
        [JsonProperty("access_token")]
        public string Password { get; set; }
        [JsonProperty("access_token")]
        public string Token { get; set; }
    }
}
