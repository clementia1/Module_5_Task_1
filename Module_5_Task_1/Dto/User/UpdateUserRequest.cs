using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Module_5_Task_1.Dto.User
{
    public class UpdateUserRequest
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("job")]
        public string Job { get; set; }
    }
}
