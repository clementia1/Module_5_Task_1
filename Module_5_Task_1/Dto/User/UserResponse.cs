using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Module_5_Task_1.Dto.User
{
    public class UserResponse
    {
        [JsonProperty("data")]
        public UserDto User { get; set; }

        [JsonProperty("support")]
        public IReadOnlyDictionary<string, string> Support { get; set; }
    }
}
