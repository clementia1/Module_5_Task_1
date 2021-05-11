using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
#nullable enable

namespace Module_5_Task_1.Dto.Unknown
{
    public class UnknownResponse
    {
        [JsonProperty(PropertyName = "data", Required = Required.AllowNull)]
        public UnknownDto? Unknown { get; set; }

        [JsonProperty(PropertyName = "support", Required = Required.AllowNull)]
        public IReadOnlyDictionary<string, string>? Support { get; set; }
    }
}
