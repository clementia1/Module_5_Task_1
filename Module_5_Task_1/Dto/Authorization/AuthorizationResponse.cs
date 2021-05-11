using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Module_5_Task_1.Dto.Authorization
{
    public class AuthorizationResponse
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("token")]
        public string Token { get; set; }

        [JsonProperty("error")]
        public string Error { get; set; }
    }
}
