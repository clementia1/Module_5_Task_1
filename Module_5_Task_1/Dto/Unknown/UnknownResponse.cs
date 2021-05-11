using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Module_5_Task_1.Dto.Unknown
{
    public class UnknownResponse
    {
        [JsonProperty("data")]
        public UnknownDto Unknown { get; set; }

        [JsonProperty("support")]
        public IReadOnlyDictionary<string, string> Support { get; set; }
    }
}
